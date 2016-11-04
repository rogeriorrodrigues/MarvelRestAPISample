using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MarvelApp
{

	public partial class PersonagemDetailsPage : ContentPage
	{
		
			
		public PersonagemDetailsPage(Result personagem)
		{
			InitializeComponent();

			imgPerson.Source = personagem.thumbnail + "jpg";
		}
	}
}
