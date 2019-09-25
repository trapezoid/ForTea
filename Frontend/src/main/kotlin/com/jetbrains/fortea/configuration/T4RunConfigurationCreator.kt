package com.jetbrains.fortea.configuration

import com.intellij.execution.*
import com.intellij.execution.executors.DefaultDebugExecutor
import com.intellij.execution.executors.DefaultRunExecutor
import com.intellij.execution.process.NopProcessHandler
import com.intellij.execution.runners.ExecutionEnvironmentBuilder
import com.intellij.openapi.project.Project
import com.intellij.openapi.vfs.VirtualFile
import com.intellij.util.PathUtil
import com.jetbrains.fortea.configuration.run.T4RunConfiguration
import com.jetbrains.fortea.configuration.run.T4RunConfigurationFactory
import com.jetbrains.fortea.configuration.run.T4RunConfigurationParameters
import com.jetbrains.rider.model.T4ExecutionRequest
import com.jetbrains.rider.model.T4FileLocation
import com.jetbrains.rider.model.t4ProtocolModel
import com.jetbrains.rider.projectView.ProjectModelViewHost
import com.jetbrains.rider.projectView.solution
import org.jetbrains.annotations.TestOnly

class T4RunConfigurationCreator(
  private val project: Project,
  private val host: ProjectModelViewHost
) {
  init {
    val model = project.solution.t4ProtocolModel
    model.requestExecution.set(launcher(DefaultRunExecutor.getRunExecutorInstance()))
    model.requestDebug.set(launcher(DefaultDebugExecutor.getDebugExecutorInstance()))
  }

  private fun launcher(executor: Executor) = { request: T4ExecutionRequest ->
    val configuration = setupFromFile(request)
    val runManager = RunManager.getInstance(project)
    val configurationSettings = runManager.createConfiguration(configuration, T4RunConfigurationFactory)
    configurationSettings.isActivateToolWindowBeforeRun = request.isVisible
    executeConfiguration(configurationSettings, executor, project)
  }

  private fun executeConfiguration(
    configuration: RunnerAndConfigurationSettings,
    executor: Executor,
    project: Project
  ) {
    val builder: ExecutionEnvironmentBuilder
    try {
      builder = ExecutionEnvironmentBuilder.create(executor, configuration)
    } catch (e: ExecutionException) {
      return
    }

    val environment = builder.contentToReuse(null).dataContext(null).activeTarget().build()
    ProgramRunnerUtil.executeConfigurationAsync(
      environment,
      true,
      true
    ) {
      val listener = project.messageBus.syncPublisher(ExecutionManager.EXECUTION_TOPIC)
      listener.processStarted(executor.id, environment, NopProcessHandler())
    }
  }

  private fun setupFromFile(request: T4ExecutionRequest): T4RunConfiguration {
    val model = project.solution.t4ProtocolModel
    val item = host.getItemById(request.location.id)
    val virtualFile = item?.getVirtualFile()!!
    val t4Path = virtualFile.path
    val protocolConfiguration = model.getConfiguration.sync(T4FileLocation(item.id))
    val parameters = T4RunConfigurationParameters(
      request,
      protocolConfiguration.executablePath,
      protocolConfiguration.outputPath,
      PathUtil.getParentPath(t4Path)
    )
    return T4RunConfiguration(virtualFile.name, project, parameters)
  }

  @TestOnly
  fun launchExecution(file: VirtualFile) {
    val id = host.getItemsByVirtualFile(file).single().id
    val request = T4ExecutionRequest(T4FileLocation(id), false)
    val launcher = launcher(DefaultDebugExecutor.getDebugExecutorInstance())
    launcher(request)
  }
}
