﻿using System;
using System.ComponentModel;

namespace DLToolkit.PageFactory
{
	public abstract class PFTabbedPage<TViewModel> : Xamarin.Forms.TabbedPage, IBasePage<TViewModel> where TViewModel : class, INotifyPropertyChanged
	{
		protected PFTabbedPage(bool forcedConstructor = true)
		{ 
			PageFactory.ResetPageViewModel(this);
		}

		public TViewModel ViewModel
		{
			get 
			{
				return BindingContext == null ? default(TViewModel) : (TViewModel)BindingContext;
			}
		}

		public virtual TViewModel ViewModelInitializer()
		{
			return Activator.CreateInstance<TViewModel>();
		}

		public IPageFactory PageFactory
		{
			get
			{
				return PF.Factory;
			}
		}

		public virtual void PageFactoryMessageReceived(string message, object sender, object arg)
		{
		}

		public virtual bool PageFactoryPushing() 
		{
			return true;
		}

		public virtual bool PageFactoryPopping()
		{
			return true;
		}

		public virtual bool PageFactoryInserting() 
		{
			return true;
		}

		public virtual bool PageFactoryRemoving()
		{
			return true;
		}

		public virtual void PageFactoryPushed() 
		{
		}

		public virtual void PageFactoryPopped()
		{
		}

		public virtual void PageFactoryInserted() 
		{
		}

		public virtual void PageFactoryRemoved()
		{
		}

		public virtual void PageFactoryRemovingFromCache()
		{
		}
	}		
}

