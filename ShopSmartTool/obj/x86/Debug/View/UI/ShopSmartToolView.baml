   M S B A M L   `   `   `  ����H  DShopSmartTool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ShopSmartTool.ViewModelShopSmartTool.ViewModel  5   	   %    ShopSmartTool.ShopSmartToolView   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   4vm%clr-namespace:ShopSmartTool.ViewModel     5   	     � WindowStartupLocation$  CenterScreen=�6:    � WindowStyle$ ThreeDBorderWindow=�6_    � Title$ Shop Smart Tool��5   	    � Icon$8 2/ShopSmartTool;component/View/Images/ShopSmart.ico��6!   $
��Auto=�6[   $
��Auto=�6�    � SizeToContent$ Height=�6�    � DataContext 5      4   .ShopSmartTool.ViewModel.ShopSmartToolViewModel  5   
   .��5	      �  � RowDefinitions 5
   
   �� 5      $��10 �6   �� 5      $
��Auto �6   �� 5      $��20 �6   �� 5      $��* �6   .+�5   
   &   System.Windows.Controls.DataGrid  $��1��6      AutoGenerateColumns .     CanUserAddRows .  	   CanUserDeleteRows	 .  $
   HorizontalScrollBarVisibility$

 Auto=�5      "   VerticalScrollBarVisibility$
 Auto=�6<   ��5       �� *	ItemsList+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Items��6%      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6c   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *
ItemName+6c   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Price��6)    . $ * 6J      CellTemplate 5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6)   .+�5   "   �� $��£��6,   �� 5   "   $
��Left=�6D   ��6,   �� *Price+6D   5      5      5        5      $ Offer��6%    . $ * 6`    64   �� *Offer+6`     5      $ 	AddToCart��6)   $ * 6<    5       �� 5!      .R�5"      ��  � ToolTip$ Add items to cart��6%   
������ ��6A   �� *DataContext.AddToCartCommand+ �� RelativeSource ��  �� AncestorType"  ��5#   %   ��  �� Path$ ItemName�.��5$   "   �� $��20��6(   $��20��64   $6��0/ShopSmartTool;component/View/Images/addCart.ico��6?   5%      5&      5(        5)      $ RemoveFromCart��6)   $ * 6A    5*      �� 5+      .R�5,      �� $ Remove items to cart��6%   
������ ��6D   �� *#!DataContext.RemoveFromCartCommand+ �� "  ��5-   %   �� $ ItemName�.��5.   "   �� $��20��6(   $��20��64   $9��3/ShopSmartTool;component/View/Images/removeCart.ico��6?   5/      50      52         RowHeaderTemplate 54      �� 55      .R�56      �� ��6    �� *DataContext.ItemId+ �� $ DataGridRowL�57      59      �� 5:   
   $��2��6   � 5;   
   $��3��6    5<      �� 5=      $
��Auto �6    �� 5>      $��10 �6    �� 5?      $
��Auto �6    .+�5A      �� ��5B      �� 5C      $��Bill Invoice Summary��6    $
��Bold"�6<   .��5E      �  5F      �� 5G      $
��Auto �6(   �� 5H      $
��Auto �6(   .+�5J      �� $��1��6   ��6-   �� *ItemsBillInfo+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� View 5K      �� 5L      .P�5M   "   �� $
��Item��61    �� DisplayMemberBinding 6?   �� *
ItemName+�� 5N   "   $	��Qty��61    6>   �� *	ItemCount+5O      5Q      5R      5S      �� 5T      $��2��6   $ 
Horizontal=�6&   $��Right=�6?   .+�5U      �� $��Center=�6   $&�� The total billable amount is: £��68   �� 5V         Special#��[  6l   ��6   �� *TotalAmount+$ TwoWay=�$ PropertyChanged=�6l   5W      5X      5Y      5Z      