   M S B A M L   `   `   `  ����=  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:UI.ViewModelsUI.ViewModels  5   	   clr-namespace:UIUI  5   	       UI.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *vmclr-namespace:UI.ViewModels     5   	   "localclr-namespace:UI     5   	     � Title$  
MainWindow��5
   	   $	��350��6   $	��525��6)    � WindowStartupLocation$ CenterScreen=�5   	    � WindowState$ 	Maximized=�6.   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��0.25* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��2��6   $��0��6   $��5q�6.   $��Загрузить��5      ��6%   �� *LoadCommand+��5      �� �� 5   
   $��2��6   $��1��6   $��5q�6.   $ ��Преобразовать��5      ��6)   �� *CompressionCommand+��5      �� �� 5   
   $��2��6   $��2��6!   $��5q�65   ��5       �� *Image+�� 5!   
   $��0��6   $��2��6   $��2��6-   $��2��5"      $��5q�6$   ��6/   �� *ConvertedImage+� 5#   
   $��0��6   $��4��6    5$      �� 5%      $
��0.5* �6    �� 5&      $
��0.5* �6    �� 5'      $
��0.5* �6    �� 5(      $��2* �6    .+�5*      �� $<��6Использовать преобразование:��6   $��5q�6;   $��Center=�5+      $��Center=�5,      	� 5-      $��1��6   $��
Хаара��6'   $
��Left=�67   $��Center=�5.      $��5q�6<    d� 	IsChecked 5/      �� *IsHaarSelected+	� 50      $��2��6   $��Добеши��6'   $
��Left=�68   $��Center=�51      $��5q�6<    52      �� *IsDaubechiesSelected+53      54      55      