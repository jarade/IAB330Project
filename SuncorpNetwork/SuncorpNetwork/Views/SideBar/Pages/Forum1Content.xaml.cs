using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace SuncorpNetwork
{
	public partial class Forum1Content : BaseView
	{

		Forum1ContentViewModel f1vm;
		public Forum1Content ()
		{
			f1vm = new Forum1ContentViewModel ();
			BindingContext = f1vm;
			InitializeComponent ();
		}

		private Forum1Post Post;

		public Forum1Content(Forum1Post post){
			f1vm = new Forum1ContentViewModel ();
			BindingContext = f1vm;
			Post = post;
			InitializeComponent ();

			StackLayout layout = new StackLayout(){
				Spacing = 10,
				Orientation = StackOrientation.Horizontal
			};

			StackLayout layout2 = new StackLayout(){
				Spacing = 10,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};

			StackLayout layout3 = new StackLayout(){
				Padding = 20,
				Spacing = 155,
				Orientation = StackOrientation.Vertical
			};

			StackLayout layout4 = new StackLayout(){
				Spacing = 20,
				Orientation = StackOrientation.Horizontal,
			};

			StackLayout layout5 = new StackLayout(){
				Spacing = 20,
				Orientation = StackOrientation.Vertical,
			};

			StackLayout layout6 = new StackLayout(){
				Spacing = 20,
				Orientation = StackOrientation.Horizontal,
			};

			Label label = new Label{
				Text = Post.Forum1PostTitle,
				FontSize = 18,
				TextColor = Color.White
			};
					
			Label label2 = new Label{
				Text = Post.Forum1PostContent,
				FontSize = 14,
				TextColor = Color.White
			};

			BoxView label3 = new BoxView{
				HeightRequest = 1,
				Color = Color.Black,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			Label label4 = new Label {
				Text = "Add Comment",
				FontSize = 18,
				TextColor = Color.White
			};

			Editor label5 = new Editor {
				BackgroundColor = Color.White,
				WidthRequest = 100,
			};

			BoxView label6 = new BoxView{
				HeightRequest = 0.5,
				Color = Color.White,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			BoxView label9 = new BoxView{
				HeightRequest = 0.5,
				Color = Color.White,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			Button label8 = new Button {
				BackgroundColor = Color.White,
				Text = "Add",
				FontSize = 10,
				HeightRequest = 40,
				WidthRequest = 60,
				TextColor = Color.Black,
				HorizontalOptions = LayoutOptions.End,
			};

			var photo = new RoundedBoxView(){
				WidthRequest = 45,
				HeightRequest = 45,
				HorizontalOptions = LayoutOptions.Center,
			};
			photo.Source = ImageSource.FromFile("xen.jpg");

			var photo2 = new RoundedBoxView(){
				WidthRequest = 45,
				HeightRequest = 45,
				HorizontalOptions = LayoutOptions.Center,
			};
			photo2.Source = ImageSource.FromFile("images.jpg");

			var photo3 = new RoundedBoxView(){
				WidthRequest = 45,
				HeightRequest = 45,
				VerticalOptions = LayoutOptions.Center
			};
			photo3.Source = ImageSource.FromFile("images.jpg");

			Label label7 = new Label{
				Text = "You are real idiot",
				FontSize = 14,
				TextColor = Color.White
			};

			layout4.Children.Add(photo);
			layout4.Children.Add(label2);

			layout6.Children.Add(photo2);
			layout6.Children.Add(label7);

			layout5.Children.Add(label);
			layout5.Children.Add(label3);
			layout5.Children.Add (layout4);
			layout5.Children.Add (label6);

			layout5.Children.Add (layout6);
			layout5.Children.Add (label9);

			layout2.Children.Add(label4);
			layout2.Children.Add(label5);
			layout2.Children.Add(label8);

			//user's photo comment box
			layout.Children.Add(photo3);
			layout.Children.Add(layout2);

//			layout3.Children.Add (layout5);
//			layout3.Children.Add (layout);
			Content.Children.Insert (0, layout5);
			Content.Children.Insert (1, layout);

			this.Content = Content;

		}



			public async void navigateToTemporaryPage(StackLayout stack){
				// Create the temporary page
				await Navigation.PushModalAsync (new BaseView {
					Padding = new Thickness(15,5,15,5),
					BackgroundColor = Color.FromHex("#0DA195"),
					Content = stack
				});
			}

			public void messageBtnClicked(object sender, EventArgs e){
				// Navigate to the Page.
				switchPage(new Messages ());
			}

			public void alertBtnClicked(object sender, EventArgs e){
				// Navigate to the Page.
				switchPage(new Alert ());
			}

			public void homeBtnClicked(object sender, EventArgs e){
				// Navigate to the Page.
				switchPage(new Home ());
			}

			public void addBtnClicked(object sender, EventArgs e){
				// Navigate to the Page.
				switchPage(new Add ());
			}

			public void profileBtnClicked(object sender, EventArgs e){
				// Navigate to the Page.
				switchPage(new PersonalProfile ());
			}

			private void switchPage(Page page){
				SideNavi curNavi = (SideNavi)this.Parent.Parent;
				curNavi.switchTo(page);
			}
		}
	}

