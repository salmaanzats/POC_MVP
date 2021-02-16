﻿using POC_MVP.BusinessLogic;
using POC_MVP.Events;
using POC_MVP.Views;
using System;
using System.Linq;

namespace POC_MVP.Presenter
{
    public class MainPresenter
    {
        private readonly IUserManager userManager;

        public MainPresenter(IMain mainFormView, IUserManager userManager)
        {
            this.userManager = userManager;
            mainFormView.Load += MainFormViewOnLoad;
        }

        private void MainFormViewOnLoad(object sender, EventArgs eventArgs)
        {

            foreach (var user in this.userManager.Users?.ToList())
            {
                EventAggregator.Instance.Publish(new UserLoadedMessage(user));
            }

            //EventAggregator.Instance.Publish(new PodcastLoadCompleteMessage(subscriptionManager.Subscriptions.ToArray()));

            //if (settingsService.FirstRun)
            //{
            //    messageBoxDisplayService.Show("Welcome! Get started by clicking Add to subscribe to a podcast");
            //    settingsService.FirstRun = false;
            //    settingsService.Save();
            //}
        }
    }
}
