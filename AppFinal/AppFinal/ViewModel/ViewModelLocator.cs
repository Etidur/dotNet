﻿using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFinal.ViewModel
{
    /// <summary>     
    /// This class contains static references to all the view models in the     
    /// application and provides an entry point for the bindings.     
    /// <para>     
    /// See http://www.mvvmlight.net     
    /// </para>     
    /// </summary>
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<HomePageViewModel>();
        }
        /// <summary>         
        /// Gets the EuroToDev model.         
        /// </summary>         
        public HomePageViewModel HomePage => ServiceLocator.Current.GetInstance<HomePageViewModel>();
    }
}
