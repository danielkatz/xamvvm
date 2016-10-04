﻿using System;
using System.ComponentModel;

namespace DLToolkit.PageFactory
{
	/// <summary>
	/// Base page.
	/// </summary>
	public interface IBasePage<TPageModel> where TPageModel: class, IBasePageModel
	{
	}
}
