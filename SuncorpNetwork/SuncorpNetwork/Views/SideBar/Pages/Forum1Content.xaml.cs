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
				Spacing = 20,
			};

			StackLayout layout2 = new StackLayout(){
				Spacing = 20,
			};

			StackLayout layout3 = new StackLayout(){
				Padding = 20,
				Spacing = 135,
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
					WidthRequest = 20	
			};

			var photo = new RoundedBoxView(){
				WidthRequest = 60,
				HeightRequest = 60,
				HorizontalOptions = LayoutOptions.Center,
			};
			photo.Source = ImageSource.FromFile("images.jpg");
			layout.Children.Add(photo);
			layout.Children.Add(label);
			layout.Children.Add(label3);
			layout.Children.Add(label2);
			layout2.Children.Add(label4);
			layout2.Children.Add(label5);
			layout3.Children.Add (layout);
			layout3.Children.Add (layout2);
			this.Content = layout3;

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

