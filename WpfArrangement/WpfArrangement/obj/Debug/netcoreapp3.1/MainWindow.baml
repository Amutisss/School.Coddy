   M S B A M L   `   `   `  ����I  EWpfArrangement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WpfArrangementWpfArrangement  5   	       WpfArrangement.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WpfArrangement     5   	   -   5          � Title$D  >Изучение языков программирования��5   	   $	��450��62   $	��800��6?    � 	Resources 5	         BorderStyleLine �� 
TargetType �� Property �� Value  TextBlockStyleHeader��%V  &	        &	 P     �� 5   
   " ��6(   .�5      ��  � �� �	#00CCCCCC6,   5      �� 5   
   " ��6-   .�5      ��  � ��$
 Bold"�6+   �� 5       � ��$ 16(�6)   �� 5       �@��Padding$ 0,0,0,0q�6(   �� 5       � �� �	#FF7777776+   �� 5       � ��$ Arial)�6+   5      5      .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FFA2D7F9��6   � 5      $ White��6    � Offset$ 1Q�6-   � 5      $ 	#FFEBF4FB��6   $ 0.143Q�61   5      	 � RowDefinitions	 5   
   �� 5       $
��Auto �6   �� 5!      �� 5"      
 � ColumnDefinitions
 5$   
   �� 5%      $
��Auto �6   �� 5&      $��* �6   �� 5'      $��* �6   .+�5+   
   �� $��0,0,1,0q�6    �� Padding$ 10,10,10,10q�6+     BorderStyle1#���  6A   $��1��6h   $��2��6u   ._�5,      �� $	��100��6   .+�5-      �� -   5         ��Name$ 
HeaderList��5-      $��Список��60   $
��Wrap=�6>    �� TextAlignment$ Center=�6R   #���  6i   �� 5.      -   5         ��Name$ ListLangProg��5.      $��0,0,0,0q�60   $��14(�6J   $��Normal"�6�   ���	#FF2C8DDE$��Normal$�6�   $��Center=�6�   $
��Left=�6�   ��6r   Z� .@�5/      �� $��C#��6"   �� 50      $	��C++��6"   �� 51      $
��Java��6"   �� 52      $��Python��6"   53      54      55      �� 59   
   -   5         ��Name$ BorderDescription��59      $��1q�6,   $��1��6A   $ 10,10,10,10q�6Q   #���   6g   $��1��6�   $��2��6�   ._�5:      ]� .+�5;      �� -   5        $ HeaderDescription��5;      $��Описание��67   $
��Wrap=�6G   $ Center=�6[   #���  6r   $	��Top=�6�   -� 5>      -   5         -�Name$ FlowDescription��5>   %   $��Bottom=�6>   $��Stretch=�6W   $
��Auto=�6|    -� IsTwoPageViewEnabled$ False��6�    -� MinZoom$ 70Q�6�    -� ViewingMode$ Scroll=�6�    -� ZoomIncrement$ 5Q�6�    -� Zoom$ 80Q�6�   ��6  Z� .��5?      /�  /� TextAlignment$ Justify=�6#    /� ColumnWidth$
 Auto��6;   5@      5B      5C      �� 5G   
   -   5        $ BorderExample��5G      #���  6(   $��1q�6O   $��2��6c   $ 10,10,10,10q�6s   $��1��6�   ._�5H      � 	 5I      �� 5J      $
��Auto �6$   �� 5K      .+�5M      �� -   5        $ HeaderExample��5M      $��Пример кода��63   $
��Wrap=�6F   $ Center=�6Z   #���  6q   �� 5N      $��1��6   $��Stretch=�6,   $��Stretch=�6Q   $
��Auto=�6t   $
��Auto=�6�   .��5O      �� 2  ,System.Windows.Markup.XmlAttributeProperties  XmlSpace preserve6t   -	   5        $ CodeExample��5O   5   $
��Wrap=�6J   $��Consolas)�6^   $��Center=�6t   5P      5Q      5R      �� 5V   
   -
   5        $ BorderRating��5V      #���  6'   $��1q�6N   $��2��6b   $ 10,10,10,10q�6r   $��2��6�   ._�5W      � 	 5X      �� 5Y      $
��Auto �6$   �� 5Z      .+�5\      �� -   5        $ HeaderRating��5\      $��Рейтинги��62   $
��Wrap=�6B   $ Center=�6V   #���  6m   �� 5]      -   5         ��Name$ Rating��5]      $
��Fill=�6(   $��1��67   5^      5_      �� 5c   
   
���   �$��3��6%   $ 
40,10,40,0q�69   $��0,0,0,5q�6N   ._�5d      �� ���	#FF959494$��0,0,0,1q�6-   $y�Visible=�6G    J� Effect 5e      3  -System.Windows.Media.Effects.DropShadowEffect  5f         
BlurRadius$ 4Q�6'   ._�5h      �� -   5        $ 
HeaderMain��5h      $��32(�60   $1��+Языки программирования��6>   $ Center=�6\   $
��Bold"�6s   $��Normal$�6�   $��Center=�6�    �� Padding$ 0,0,0,10q�6�   ���	#FFB6B4B4$
��Wrap=�6�   5i      5j      �� 5n   
   -   5        $ SplashScreen��5n      $��2��6&   $��2��67   $��/SplashScreen.png��6K   $��1��6f   $��1��6s   5p      5q      