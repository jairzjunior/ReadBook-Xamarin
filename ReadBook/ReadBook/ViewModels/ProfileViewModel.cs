﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReadBook.Models;

namespace ReadBook.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {	
        public User User { get; set; }

		Gamification gamification = null;
		public Gamification Gamification
		{
			get { return gamification; }
			set { SetProperty(ref gamification, value); }
		}

		public ProfileViewModel()
        {
			Title = "Perfil";
			User = App.User;

			LoadGamification();
        }

		public async void LoadGamification()
		{            
            var gamifications = await DataStore.Connection.Table<Gamification>().ToListAsync();
            if (gamifications != null)
			{
				Gamification = gamifications.FirstOrDefault(a => a.UserId == User.Id);
			}
		}
    }
}