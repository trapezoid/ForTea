using GammaJul.ForTea.Core.Tree;
using JetBrains.ReSharper.Psi.CSharp.Impl.CodeStyle;

namespace GammaJul.ForTea.Core.Psi.Formatting.SpaceTypeProviders.Impl
{
	internal sealed class T4InsideExpressionBlockSpaceTypeProvider : T4BlockSpaceTypeProviderBase
	{
		protected override bool IsApplicable(CSharpFmtStageContext ctx)
		{
			var leftExpressionBlock = ctx.LeftChild.GetT4ContainerFromCSharpNode<IT4ExpressionBlock>();
			var rightExpressionBlock = ctx.RightChild.GetT4ContainerFromCSharpNode<IT4ExpressionBlock>();
			if (leftExpressionBlock == null || rightExpressionBlock == null) return false;
			return leftExpressionBlock == rightExpressionBlock;
		}

		protected override SpaceType Type => SpaceType.Horizontal;
	}
}
