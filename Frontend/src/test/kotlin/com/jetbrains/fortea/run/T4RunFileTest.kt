package com.jetbrains.fortea.run

import org.testng.annotations.Test

// Important note:
//   method names will at some point be parsed as program arguments,
//   so they cannot contain spaces!

class T4RunFileTest : T4RunFileTestBase() {
  @Test fun testThatFileCanBeExecuted() = doTest(dumpCsproj = true)
  @Test fun testThatHostSpecificTemplateCanBeExecuted() = doTest(dumpCsproj = true)
  @Test fun testThatHostCanSetResultExtension() {
    doTest(".cshtml", true)
    assertNoOutputWithExtension(".html")
  }

  @Test fun testThatTtincludeFileCanBeIncluded() = doTest(dumpCsproj = true)
  @Test fun testThatCSharpFileCanBeIncluded() = doTest(dumpCsproj = true)
  @Test fun testThatVsMacrosAreResolved() = doTest(dumpCsproj = true)
  @Test fun testThatMsBuildPropertiesAreResolved() = doTest(dumpCsproj = true)
  @Test fun testThatAssemblyCanBeReferenced() = doTest(dumpCsproj = true)
  @Test fun testTransitiveReferencesInRuntime() = doTest(dumpCsproj = true)
  @Test fun testTransitiveReferencesInCompilation() {
    executeT4File()
    saveSolution()
    assertNoOutputWithExtension(".cs")
  }
//  @Test fun testThatFileCanBeExecutedInDotNetCoreProject() = doTest(dumpCsproj = true)
  @Test fun testThatTemplateCanProduceBigXml() = doTest(dumpCsproj = true)
  @Test fun testThatTemplateIsCaseInsensitive() = doTest(dumpCsproj = true)
//  @Test fun testThatFileExtensionCanBeUpdatedCorrectly() {
//    executeT4File()
//    t4File.writeText(t4File.readText().replace(".fs", ".cs"))
//    todo: saveSolution()? or see @korifey dialog for details on how to force update from disk
//    executeT4File()
//    saveSolution()
//    dumpExecutionResult(".cs")
//    dumpCsproj()
//    assertNoOutputWithExtension(".fs")
//  }
  @Test fun testThatVsDefaultTemplateCanBeExecuted() = doTest(dumpCsproj = true)
  @Test fun testThatDefaultExtensionIsCs() = doTest(".cs", true)
  @Test fun testThatFileWithT4ExtensionCanBeExecuted() = doTest(dumpCsproj = true)
  @Test fun testThatExtensionCanContainDot() = doTest(".txt", true)
  @Test fun testThatExtensionCanBeWithoutDot() = doTest(".txt", true)
  @Test fun testTemplateWithLineBreakMess() = doTest(dumpCsproj = true)
  @Test fun testThatFeatureBlocksCanContainManyNewLines() = doTest(dumpCsproj = true)
  @Test fun testHowTextInFeatureIsHandled() = doTest(dumpCsproj = true)
//  @Test fun testThatOutputOfUnbuiltProjectCanBeReferenced() = doTest(dumpCsproj = true)
  @Test fun testHostInHostSpecificTemplate() = doTest(dumpCsproj = true)
  @Test fun testHostInNonHostSpecificTemplate() {
    executeT4File()
    saveSolution()
    assertNoOutputWithExtension(".txt")
    dumpCsproj()
  }

  @Test fun testInProjectTransitiveIncludeResolution() = doTest(dumpCsproj = true)
  @Test fun testOutOfProjectTransitiveIncludeResolution() = doTest(dumpCsproj = true)
  @Test fun testInProjectNonTrivialIncludeResolution() = doTest(dumpCsproj = true)
  @Test fun testDefaultReferences() = doTest()
  @Test fun testHostSpecificDefaultReferences() = doTest()
  @Test fun testThatHostSpecificTemplateCanAccessEnvDTE() = doTest()
}
