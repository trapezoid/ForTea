﻿#region License
//    Copyright 2012 Julien Lebosquain
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
#endregion
using JetBrains.Annotations;

namespace GammaJul.ReSharper.ForTea.Tree {

	/// <summary>
	/// Represents a T4 node that can have a name.
	/// </summary>
	public interface IT4NamedNode : IT4TreeNode {

		/// <summary>
		/// Gets the name of the node.
		/// </summary>
		/// <returns>The node name, or <c>null</c> if none is available.</returns>
		[CanBeNull]
		string GetName();

		/// <summary>
		/// Gets the token representing the name of this node.
		/// </summary>
		/// <returns>The name token, or <c>null</c> if none is available.</returns>
		[CanBeNull]
		IT4Token GetNameToken();

	}

}