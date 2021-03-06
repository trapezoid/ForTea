using GammaJul.ForTea.Core.TemplateProcessing.CodeCollecting.Interrupt;
using GammaJul.ForTea.Core.Tree;
using JetBrains.Annotations;
using JetBrains.ProjectModel;

namespace GammaJul.ForTea.Core.TemplateProcessing.CodeCollecting
{
	public sealed class T4CSharpCodeBehindGenerationInfoCollector : T4CSharpCodeGenerationInfoCollectorBase
	{
		protected override IT4CodeGenerationInterrupter Interrupter { get; } = new T4CodeBehindGenerationInterrupter();

		public T4CSharpCodeBehindGenerationInfoCollector(
			[NotNull] IT4File file,
			[NotNull] ISolution solution
		) : base(file, solution)
		{
		}

		// There's no way tokens can code blocks, so there's no need to insert them into code behind
		protected override void AppendTransformation(string message)
		{
		}
	}
}
