//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.Composition;
using System.Windows.Media;
using JetBrains.Platform.VisualStudio.SinceVs10.TextControl.Markup.FormatDefinitions;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using JetBrains.TextControl.DocumentMarkup;
using GammaJul.ForTea.Core.Daemon.Attributes;
using JetBrains.ForTea.ReSharperPlugin.Daemon.Attributes;
#region registraction
[assembly: RegisterHighlighter(
	T4ReSharperCustomHighlightingIds.BLOCK_TAG,
	GroupId = T4HighlightingAttributeGroup.ID,
	EffectType = EffectType.TEXT,
	ForegroundColor = "#000000",
	BackgroundColor = "#FBFB64",
	Layer = HighlighterLayer.ADDITIONAL_SYNTAX,
	VSPriority = VSPriority.IDENTIFIERS
)]
[assembly: RegisterHighlighter(
	T4ReSharperCustomHighlightingIds.DIRECTIVE,
	GroupId = T4HighlightingAttributeGroup.ID,
	EffectType = EffectType.TEXT,
	ForegroundColor = "#800080",
	BackgroundColor = "#FFFFFF",
	Layer = HighlighterLayer.ADDITIONAL_SYNTAX,
	VSPriority = VSPriority.IDENTIFIERS
)]
[assembly: RegisterHighlighter(
	T4ReSharperCustomHighlightingIds.DIRECTIVE_ATTRIBUTE,
	GroupId = T4HighlightingAttributeGroup.ID,
	EffectType = EffectType.TEXT,
	ForegroundColor = "#00008B",
	BackgroundColor = "#FFFFFF",
	Layer = HighlighterLayer.ADDITIONAL_SYNTAX,
	VSPriority = VSPriority.IDENTIFIERS
)]
[assembly: RegisterHighlighter(
	T4ReSharperCustomHighlightingIds.ATTRIBUTE_VALUE,
	GroupId = T4HighlightingAttributeGroup.ID,
	EffectType = EffectType.TEXT,
	ForegroundColor = "#9C5800",
	BackgroundColor = "#FFFFFF",
	Layer = HighlighterLayer.ADDITIONAL_SYNTAX,
	VSPriority = VSPriority.IDENTIFIERS
)]
#endregion

namespace JetBrains.ForTea.ReSharperPlugin.Daemon.Attributes
{
	#region IDs
	public static class T4ReSharperCustomHighlightingIds
	{
		public const string BLOCK_TAG = "T4 Block Tag";
		public const string DIRECTIVE = "T4 Directive";
		public const string DIRECTIVE_ATTRIBUTE = "T4 Directive Attribute";
		public const string ATTRIBUTE_VALUE = "T4 Attribute Value";
	}
	#endregion

	#region block tag
	[ClassificationType(ClassificationTypeNames = Name)]
	[Order(
		After = VsSyntaxPriorityClassificationDefinition.Name,
		Before = VsAnalysisPriorityClassificationDefinition.Name
	)]
	[Export(typeof(EditorFormatDefinition))]
	[Name(Name)]
	[System.ComponentModel.DisplayName(Name)]
	[UserVisible(true)]
	internal sealed class BlockTagClassificationFormatDefinition : ClassificationFormatDefinition
	{
		private const string Name = T4ReSharperCustomHighlightingIds.BLOCK_TAG;
		
		public BlockTagClassificationFormatDefinition()
		{
			DisplayName = Name;
			BackgroundColor = Color.FromRgb(0xFB, 0xFB, 0x64);
			ForegroundColor = Color.FromRgb(0x00, 0x00, 0x00);
		}
		
		[Export, Name(Name), BaseDefinition("formal language")]
		internal ClassificationTypeDefinition ClassificationTypeDefinition;
	}
	#endregion 

	#region directive
	[ClassificationType(ClassificationTypeNames = Name)]
	[Order(
		After = VsSyntaxPriorityClassificationDefinition.Name,
		Before = VsAnalysisPriorityClassificationDefinition.Name
	)]
	[Export(typeof(EditorFormatDefinition))]
	[Name(Name)]
	[System.ComponentModel.DisplayName(Name)]
	[UserVisible(true)]
	internal sealed class DirectiveClassificationFormatDefinition : ClassificationFormatDefinition
	{
		private const string Name = T4ReSharperCustomHighlightingIds.DIRECTIVE;
		
		public DirectiveClassificationFormatDefinition()
		{
			DisplayName = Name;
			ForegroundColor = Color.FromRgb(0x80, 0x00, 0x80);
		}
		
		[Export, Name(Name), BaseDefinition("formal language")]
		internal ClassificationTypeDefinition ClassificationTypeDefinition;
	}
	#endregion 

	#region directive attribute
	[ClassificationType(ClassificationTypeNames = Name)]
	[Order(
		After = VsSyntaxPriorityClassificationDefinition.Name,
		Before = VsAnalysisPriorityClassificationDefinition.Name
	)]
	[Export(typeof(EditorFormatDefinition))]
	[Name(Name)]
	[System.ComponentModel.DisplayName(Name)]
	[UserVisible(true)]
	internal sealed class DirectiveAttributeClassificationFormatDefinition : ClassificationFormatDefinition
	{
		private const string Name = T4ReSharperCustomHighlightingIds.DIRECTIVE_ATTRIBUTE;
		
		public DirectiveAttributeClassificationFormatDefinition()
		{
			DisplayName = Name;
			ForegroundColor = Color.FromRgb(0x00, 0x00, 0x8B);
		}
		
		[Export, Name(Name), BaseDefinition("formal language")]
		internal ClassificationTypeDefinition ClassificationTypeDefinition;
	}
	#endregion 

	#region attribute value
	[ClassificationType(ClassificationTypeNames = Name)]
	[Order(
		After = VsSyntaxPriorityClassificationDefinition.Name,
		Before = VsAnalysisPriorityClassificationDefinition.Name
	)]
	[Export(typeof(EditorFormatDefinition))]
	[Name(Name)]
	[System.ComponentModel.DisplayName(Name)]
	[UserVisible(true)]
	internal sealed class AttributeValueClassificationFormatDefinition : ClassificationFormatDefinition
	{
		private const string Name = T4ReSharperCustomHighlightingIds.ATTRIBUTE_VALUE;
		
		public AttributeValueClassificationFormatDefinition()
		{
			DisplayName = Name;
			ForegroundColor = Color.FromRgb(0x9C, 0x58, 0x00);
		}
		
		[Export, Name(Name), BaseDefinition("formal language")]
		internal ClassificationTypeDefinition ClassificationTypeDefinition;
	}
	#endregion 
}
