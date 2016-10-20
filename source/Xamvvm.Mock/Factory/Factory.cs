﻿using System;
namespace Xamvvm
{
	public partial class XamvvmMockFactory : IBaseFactory
	{
		IBaseLogger logger;
		public IBaseLogger Logger
		{
			get
			{
				if (logger == null)
					logger = new BaseLogger();

				return logger;
			}

			set
			{
				logger = value;
			}
		}

		public virtual IBasePage<TPageModel> GetPageByModel<TPageModel>(TPageModel pageModel) where TPageModel : class, IBasePageModel
		{
			object page = null;
			_weakPageCache.TryGetValue(pageModel, out page);
			return page as IBasePage<TPageModel>;
		}

		public virtual TPageModel GetPageModel<TPageModel>(IBasePage<TPageModel> page) where TPageModel : class, IBasePageModel
		{
			var xfPage = page as MockPage<TPageModel>;
			return xfPage?.BindingContext;
		}

		public virtual void SetPageModel<TPageModel>(IBasePage<TPageModel> page, TPageModel newPageModel) where TPageModel : class, IBasePageModel
		{
			((MockPage<TPageModel>)page).BindingContext = newPageModel;
			AddToWeakCacheIfNotExists(page, newPageModel);
		}
	}
}