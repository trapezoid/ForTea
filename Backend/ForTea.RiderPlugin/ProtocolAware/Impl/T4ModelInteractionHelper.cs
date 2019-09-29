using System;
using System.Linq;
using GammaJul.ForTea.Core.Psi;
using GammaJul.ForTea.Core.Tree;
using JetBrains.Annotations;
using JetBrains.Core;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Host.Features.ProjectModel.View;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.Files;
using JetBrains.ReSharper.Resources.Shell;
using JetBrains.Rider.Model;
using JetBrains.Util;

namespace JetBrains.ForTea.RiderPlugin.ProtocolAware.Impl
{
	[SolutionComponent]
	public class T4ModelInteractionHelper : IT4ModelInteractionHelper
	{
		[NotNull]
		private ProjectModelViewHost Host { get; }

		[NotNull]
		private ILogger Logger { get; }

		public T4ModelInteractionHelper([NotNull] ProjectModelViewHost host, [NotNull] ILogger logger)
		{
			Host = host;
			Logger = logger;
		}

		[NotNull]
		public Func<T4FileLocation, T> Wrap<T>(Func<IT4File, T> wrappee, T defaultValue) where T : class =>
			location =>
			{
				var result = Logger.Catch(() =>
				{
					using (ReadLockCookie.Create())
					{
						var file = Host
							.GetItemById<IProjectFile>(location.Id)
							?.ToSourceFile()
							?.GetPsiFiles(T4Language.Instance)
							.OfType<IT4File>()
							.SingleItem();
						return file == null ? null : wrappee(file);
					}
				});
				return result ?? defaultValue;
			};

		[NotNull]
		public Func<T4FileLocation, Unit> Wrap(Action<IT4File> wrappee) => location =>
		{
			Logger.Catch(() =>
			{
				using (ReadLockCookie.Create())
				{
					var file = Host
						.GetItemById<IProjectFile>(location.Id)
						?.ToSourceFile()
						?.GetPsiFiles(T4Language.Instance)
						.OfType<IT4File>()
						.SingleItem();
					if (file != null) wrappee(file);
				}
			});
			return Unit.Instance;
		};
	}
}
