using System.Collections.Generic;
using JetBrains.Annotations;

namespace GammaJul.ForTea.Core.Psi.Utils
{
	public sealed class T4IncludeGuard<T> where T : class
	{
		[NotNull]
		private IEqualityComparer<T> Comparer { get; }

		[NotNull, ItemCanBeNull]
		private ISet<T> SeenFiles { get; }

		[NotNull, ItemCanBeNull]
		private Stack<T> FilesBeingProcessed { get; }

		public T4IncludeGuard([NotNull] EqualityComparer<T> comparer)
		{
			Comparer = comparer;
			FilesBeingProcessed = new Stack<T>();
			SeenFiles = new HashSet<T>();
		}

		public bool CanProcess([NotNull] T file) => !FilesBeingProcessed.Contains(file);

		public void StartProcessing([CanBeNull] T file)
		{
			FilesBeingProcessed.Push(file);
			SeenFiles.Add(file);
		}

		public bool HasSeenFile([NotNull] T file) => SeenFiles.Contains(file);
		public void EndProcessing() => FilesBeingProcessed.Pop();
		public bool IsOnTopLevel => FilesBeingProcessed.Count == 1;

		public void TryEndProcessing([CanBeNull] T file)
		{
			if (file == null) return;
			if (FilesBeingProcessed.Peek().Equals(file)) FilesBeingProcessed.Pop();
		}
	}
}
