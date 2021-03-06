using GammaJul.ForTea.Core.TemplateProcessing.CodeCollecting.Interrupt;
using GammaJul.ForTea.Core.Tree;
using JetBrains.Annotations;
using JetBrains.ProjectModel;

namespace GammaJul.ForTea.Core.TemplateProcessing.CodeCollecting
{
	public sealed class T4CSharpCodeGenerationInfoCollector : T4CSharpCodeGenerationInfoCollectorBase
	{
		protected override IT4CodeGenerationInterrupter Interrupter { get; } = new T4CodeGenerationInterrupter();

		public T4CSharpCodeGenerationInfoCollector(
			[NotNull] IT4File file,
			[NotNull] ISolution solution
		) : base(file, solution)
		{
		}

		protected override void AppendTransformation(string message)
		{
			if (Result.FeatureStarted) Result.AppendFeature(message);
			else Result.AppendTransformation(message);
		}
	}
}
