using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace WpfApp1.Model
{
    public class FoodItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    class Search : INotifyPropertyChanged
    {
        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged(nameof(SearchText));
                    FilterItems();
                }
            }
        }

        private ObservableCollection<FoodItem> _allItems;
        public ObservableCollection<FoodItem> AllItems
        {
            get { return _allItems; }
            set
            {
                _allItems = value;
                OnPropertyChanged(nameof(AllItems));
                FilterItems();
            }
        }

        private ObservableCollection<FoodItem> _filteredItems;
        public ObservableCollection<FoodItem> FilteredItems
        {
            get { return _filteredItems; }
            set
            {
                _filteredItems = value;
                OnPropertyChanged(nameof(FilteredItems));
            }
        }

        public Search()
        {
            // Sample data
            _allItems = new ObservableCollection<FoodItem>
            {
                new Model.FoodItem { Name = "Chicken Breast (cooked, skinless)", Description = "~165 calories per 100g" },
                new Model.FoodItem { Name = "Salmon (cooked)", Description = "~206 calories per 100g" },
                new Model.FoodItem { Name = "Broccoli (steamed)", Description = "~55 calories per 100g" },
                new Model.FoodItem { Name = "Brown Rice (cooked)", Description = "~111 calories per 100g" },
                new Model.FoodItem { Name = "Quinoa (cooked)", Description = "~120 calories per 100g" },
                new Model.FoodItem { Name = "Eggs", Description = "~155 calories per 100g" },
                new Model.FoodItem { Name = "Sweet Potato (baked)", Description = "~86 calories per 100g" },
                new Model.FoodItem { Name = "Spinach (raw)", Description = "~23 calories per 100g" },
                new Model.FoodItem { Name = "Oatmeal (cooked)", Description = "~68 calories per 100g" },
                new Model.FoodItem { Name = "Banana", Description = "~89 calories per 100g" },
                new Model.FoodItem { Name = "Avocado", Description = "~160 calories per 100g" },
                new Model.FoodItem { Name = "Almonds (approximate)", Description = "~576 calories per 100g" },
                new Model.FoodItem { Name = "Greek Yogurt (plain, non-fat)", Description = "~59 calories per 100g" },
                new Model.FoodItem { Name = "Chicken Thigh (cooked, skinless)", Description = "~209 calories per 100g" },
                new Model.FoodItem { Name = "Pasta (cooked)", Description = "~131 calories per 100g" },
                new Model.FoodItem { Name = "Chocolate (dark)", Description = "~546 calories per 100g" },
                new Model.FoodItem { Name = "Cheese (cheddar)", Description = "~403 calories per 100g" },
                new Model.FoodItem { Name = "Beef (cooked)", Description = "~250 calories per 100g" },
                new Model.FoodItem { Name = "Potato (baked)", Description = "~93 calories per 100g" },
                new Model.FoodItem { Name = "Tomato", Description = "~18 calories per 100g" },
                new Model.FoodItem { Name = "Apple", Description = "~52 calories per 100g" },
                new Model.FoodItem { Name = "Carrot", Description = "~41 calories per 100g" },
                new Model.FoodItem { Name = "Peanut Butter", Description = "~588 calories per 100g" },
                new Model.FoodItem { Name = "Bread (whole wheat)", Description = "~247 calories per 100g" },
                new Model.FoodItem { Name = "Milk (whole)", Description = "~61 calories per 100g" },
                new Model.FoodItem { Name = "Ice Cream (vanilla)", Description = "~207 calories per 100g" },
                new Model.FoodItem { Name = "Honey", Description = "~304 calories per 100g" },
                new Model.FoodItem { Name = "Orange", Description = "~43 calories per 100g" },
                new Model.FoodItem { Name = "Salad (mixed greens)", Description = "~5 calories per 100g" },
                new Model.FoodItem { Name = "Shrimp (cooked)", Description = "~99 calories per 100g" },
                new Model.FoodItem { Name = "Blueberries", Description = "~57 calories per 100g" },
                new Model.FoodItem { Name = "Asparagus (steamed)", Description = "~20 calories per 100g" },
                new Model.FoodItem { Name = "Cucumber", Description = "~16 calories per 100g" },
                new Model.FoodItem { Name = "Watermelon", Description = "~30 calories per 100g" },
                new Model.FoodItem { Name = "Lentils (cooked)", Description = "~116 calories per 100g" },
                new Model.FoodItem { Name = "Tofu", Description = "~144 calories per 100g" },
                new Model.FoodItem { Name = "Pineapple", Description = "~50 calories per 100g" },
                new Model.FoodItem { Name = "Spinach Salad", Description = "~15 calories per 100g" },
                new Model.FoodItem { Name = "Pomegranate", Description = "~83 calories per 100g" },
                new Model.FoodItem { Name = "Quiche Lorraine", Description = "~330 calories per 100g" },
                new Model.FoodItem { Name = "Mango Slices", Description = "~60 calories per 100g" },
                new Model.FoodItem { Name = "Roasted Brussels Sprouts", Description = "~43 calories per 100g" },
                new Model.FoodItem { Name = "Chia Pudding", Description = "~120 calories per 100g" },
                new Model.FoodItem { Name = "Artichoke Hearts (canned)", Description = "~30 calories per 100g" },
                new Model.FoodItem { Name = "Lobster Tail (cooked)", Description = "~98 calories per 100g" },
                new Model.FoodItem { Name = "Pumpkin Seeds", Description = "~574 calories per 100g" },
                new Model.FoodItem { Name = "Cottage Cheese", Description = "~98 calories per 100g" },
                new Model.FoodItem { Name = "Pesto Pasta", Description = "~303 calories per 100g" },
                new Model.FoodItem { Name = "Mushroom Risotto", Description = "~96 calories per 100g" },
                new Model.FoodItem { Name = "Guacamole", Description = "~160 calories per 100g" },
                new Model.FoodItem { Name = "Sushi Rolls", Description = "~250 calories per 100g" },
                new Model.FoodItem { Name = "Lemon Sorbet", Description = "~144 calories per 100g" },
                new Model.FoodItem { Name = "Grilled Steak", Description = "~250 calories per 100g" },
                new Model.FoodItem { Name = "Pulled Pork Sandwich", Description = "~220 calories per 100g" },
                new Model.FoodItem { Name = "Chicken Fried Rice", Description = "~168 calories per 100g" },
                new Model.FoodItem { Name = "Beef Stir-Fry", Description = "~200 calories per 100g" },
                new Model.FoodItem { Name = "Sushi Nigiri", Description = "~45 calories per piece" },
                new Model.FoodItem { Name = "Lollipop", Description = "~50 calories each" },
                new Model.FoodItem { Name = "Chicken Shawarma", Description = "~195 calories per 100g" },
                new Model.FoodItem { Name = "Jasmine Rice (cooked)", Description = "~130 calories per 100g" },
                new Model.FoodItem { Name = "Chocolate Truffles", Description = "~450 calories per 100g" },
                new Model.FoodItem { Name = "Pork Belly Bao", Description = "~350 calories per serving" },
                new Model.FoodItem { Name = "Caramel Popcorn", Description = "~150 calories per 100g" },
                new Model.FoodItem { Name = "Salmon Sashimi", Description = "~60 calories per 100g" },
                new Model.FoodItem { Name = "Coconut Rice Pudding", Description = "~180 calories per serving" },
                new Model.FoodItem { Name = "Beef Jerky", Description = "~410 calories per 100g" },
                new Model.FoodItem { Name = "Gummy Bears", Description = "~87 calories per 100g" },
                new Model.FoodItem { Name = "Lamb Chops", Description = "~250 calories per 100g" },
            };

            _filteredItems = new ObservableCollection<FoodItem>(_allItems);

            FilterItems();
        }

        private void FilterItems()
        {
            var filtered = string.IsNullOrEmpty(SearchText)
                ? _allItems
                : new ObservableCollection<FoodItem>(_allItems.Where(item => item.Name.Contains(SearchText)));

            FilteredItems = filtered;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}