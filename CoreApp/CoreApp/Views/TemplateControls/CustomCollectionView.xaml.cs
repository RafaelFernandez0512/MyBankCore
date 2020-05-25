using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoreApp.Views.TemplateControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomCollectionView : ContentView
    {
        public static readonly BindableProperty ItemSourcesProperty = BindableProperty.Create(nameof(ItemSources),typeof(IList),typeof(CustomCollectionView), propertyChanged:ItemSourcesChanged);
        public static readonly BindableProperty EmptyProperty = BindableProperty.Create(nameof(Empty), typeof(string), typeof(CustomCollectionView));
        public string Empty
        {
            get => (string)GetValue(EmptyProperty);
            set => SetValue(EmptyProperty, value);
        }
        public IList ItemSources
        { 
            get=> (IList)GetValue(ItemSourcesProperty); 
            set=> SetValue(ItemSourcesProperty, value);  
        }
        private static void ItemSourcesChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is CustomCollectionView control)) return;
            var items = (IList)newValue;
            control.ListContent.ItemsSource = items;

        }
        public CustomCollectionView()
        {
            InitializeComponent();
        }
    }
}