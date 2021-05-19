﻿using AvatarView.Model;
using System;
using System.IO;
using Xamarin.Forms;

namespace AvatarView.ViewModel
{
    public class AvatarViewViewModel : BaseViewModel
    {
        public AvatarViewModel AvatarView { get; set; }

        public AvatarViewViewModel()
        {
            string ImageSourceString = "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";

            AvatarView = new AvatarViewModel {
                ImageSourceString = ImageSourceString,

                ImageSourceStream = ImageSource.FromStream(() =>
                {
                    return new MemoryStream(Convert.FromBase64String(ImageSourceString));
                })
            };

            OnPropertyChanged(nameof(AvatarView));
        }
    }
}
