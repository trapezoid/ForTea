using System.Linq;
using GammaJul.ForTea.Core.ProtocolDependent;
using GammaJul.ForTea.Core.Psi;
using GammaJul.ForTea.Core.Tree;
using JetBrains.Annotations;
using JetBrains.ForTea.RiderPlugin.TemplateProcessing.Managing;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Host.Features;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.Files;
using JetBrains.ReSharper.Resources.Shell;
using JetBrains.Rider.Model;
using JetBrains.Util;

namespace JetBrains.ForTea.RiderPlugin.ProtocolDependent
{
	[SolutionComponent]
	public class T4ProtocolModelUpdater : IT4ProtocolModelUpdater
	{
		[NotNull]
		private T4ProtocolModel Model { get; }

		[NotNull]
		private ISolution Solution { get; }

		[NotNull]
		private IT4TargetFileManager Manager { get; }

		public T4ProtocolModelUpdater([NotNull] ISolution solution, [NotNull] IT4TargetFileManager manager)
		{
			Solution = solution;
			Manager = manager;
			Model = solution.GetProtocolSolution().GetT4ProtocolModel();
			Model.RequestCompilation.Set(Compile);
		}

		public void UpdateFileInfo(IT4File file) =>
			Model.Configurations[file.GetSourceFile().GetLocation().FullPath.Replace("\\", "/")] =
				new T4ConfigurationModel(
					Manager.GetTemporaryExecutableLocation(file).FullPath.Replace("\\", "/"),
					Manager.GetTargetFileName(file)
				);

		private bool Compile(string rawPath)
		{
			try
			{
				var path = FileSystemPath.Parse(rawPath);
				using (ReadLockCookie.Create())
				{
					var sourceFile = path.FindSourceFileInSolution(Solution);
					var t4File = sourceFile?.GetPsiFiles(T4Language.Instance).OfType<IT4File>().SingleOrDefault();
					if (t4File == null) return false;
					return true;
				}
			}
			catch
			{
				return false;
			}
		}
	}
}
