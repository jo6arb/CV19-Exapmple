using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using CV19.Models.Decanat;

namespace CV19
{

    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GroupsCollection_OnFIlter(object sender, FilterEventArgs e)
        {
            if(!(e.Item is Group group)) return;
            if(group.Name is null) return;

            var filterText = GroupNameFilterText.Text;
            if(filterText.Length == 0) return;

            if(group.Name.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;
            if(group.Description != null && group.Description.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;

            e.Accepted = false;
        }

        private void OnGroupsFilterTextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = (TextBox) sender;
            var collection = (CollectionViewSource)textBox.FindResource("GroupCollection");
            collection.View.Refresh();
        }
    }
}
