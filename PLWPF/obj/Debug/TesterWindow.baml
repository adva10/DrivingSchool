   M S B A M L   `   `   `  ����@  <PLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PLWPFPLWPF  5   	       PLWPF.TesterWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:PLWPF     5   	     � Title$  TesterWindow��5   	   $	��350��6   $	��600��6+   .��5	      � .+�5
   
   � $
��Left=�6   $��77��6*   $	��Top=�66   $	��592��6N   .+�5      �� $��hello ,��6   $
��Left=�6&   $	��Top=�6A   $��56��6Y   $��58��6d   $��18(�6p   $��0,19,0,0q�6~   5      �� 5   
   -   5         ��Name$ 
stackPanel��5       �� Orientation$ Vertical=�6*   .+�5      �� $��34��63   $��70,20,346,0q�6?   $��18(�6T   ��6   �� *	FirstName+6T   5      �� 5   
   -   5        $��SignOut��5      $��497,10,10,256q�6#   $��0q�6P   ���	#FF631A13$��14(�6{   ��6:   Z� 6�   � 5   
   $
��Left=�6   $	��242��6*   $��0,77,0,0q�67   $	��Top=�6I   $	��184��6a    � ColumnDefinitions 5      �� 5      $	��99* �6#   �� 5      $	��85* �6#    � RowDefinitions 5      �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    .+�5       �� -   5        $��Update��5       $��Update Account��6#   $
��Left=�6<   $	��Top=�6W   $	��163��6o   $��81��6{   ���	#FFD2C8DC$��16(�6�   $��2��6�   �� 5!      -   5        $
��Data��5!      $��General info��6!   $
��Left=�68   $	��Top=�6S   $	��163��6k   $��80��6w   $��1��6�   ���	#FFD2C8DC$��16(�6�   $��2��6�   �� 5"      -   5        $��
Start_Test��5"      $��
Start test��6'   $	��Top=�6<   $��81��6T   $��2��6`   ���	#FFADD888$��20(�6�   $��2��6�   $��0,0,21,0q�6�   5#      � 5'   
   $
��Left=�6   $	��242��6*   $��
184,77,0,0q�67   $	��Top=�6K   $	��408��6c   .+�5(      �� $��Your Schedule:��6   $
��Left=�6-   $	��Top=�6H   $	��232��6`   $��14(�6l   ���	#00000000���	#FF060301$
��Bold"�6�   � 5)      $
��Left=�6   $	��198��6.   $��0,44,0,0q�6;   $	��Top=�6M   $	��408��6e    5*      �� 5+      $��50 �6'   �� 5,      $��* �6'   �� 5-      $��* �6'   �� 5.      $��* �6'   �� 5/      $��* �6'   �� 50      $��* �6'    52      �� 53      $��* �6$   �� 54      $��* �6$   �� 55      $��* �6$   �� 56      $��* �6$   �� 57      $��* �6$   �� 58      $��* �6$   �� 59      $��* �6$   .+�5;      �� -   5        $	��a00��5;      $
��Left=�6(   $��1��6C   $
��Wrap=�6P   $��	TextBlock��6d   $	��Top=�6u   $��67��6�   $��28��6�   $��1,0,0,0q�6�   $��1��6�   �� 5<      -   5        $	��a20��5<      $
��Left=�6'   $��3��6B   $
��Wrap=�6O   $��	TextBlock��6c   $	��Top=�6t   $��67��6�   $��28��6�   $��1��6�   $��1,0,0,0q�6�   �� 5=      -   5        $	��a02��5=      $
��Left=�6'   $
��Wrap=�6B   $��	TextBlock��6V   $	��Top=�6g   $��67��6   $��28��6�   $��3��6�   $��1��6�   �� 5>      -	   5        $	��a11��5>      $
��Left=�6'   $
��Wrap=�6B   $��	TextBlock��6V   $	��Top=�6g   $��67��6   $��28��6�   $��2��6�   $��2��6�   �� 5?      -
   5        $	��a01��5?      $
��Left=�6'   $
��Wrap=�6B   $��	TextBlock��6V   $	��Top=�6g   $��67��6   $��28��6�   $��2��6�   $��1��6�   �� 5@      -   5        $	��a23��5@      $
��Left=�6'   $��3��6B   $
��Wrap=�6O   $��	TextBlock��6c   $	��Top=�6t   $��67��6�   $��28��6�   $��4��6�   $��1,0,0,0q�6�    J� RenderTransformOrigin$ 0.612,0.576&�6�   �� 5A      -   5        $	��a24��5A      $
��Left=�6'   $��3��6B   $
��Wrap=�6O   $��	TextBlock��6c   $	��Top=�6t   $��67��6�   $��28��6�   $��5��6�   �� 5B      -   5        $	��a22��5B      $
��Left=�6'   $��3��6B   $
��Wrap=�6O   $��	TextBlock��6c   $	��Top=�6t   $��67��6�   $��28��6�   $��3��6�   �� 5C      -   5        $	��a21��5C      $
��Left=�6'   $��3��6B   $
��Wrap=�6O   $��	TextBlock��6c   $	��Top=�6t   $��67��6�   $��28��6�   $��2��6�   $��1,0,0,0q�6�   �� 5D      -   5        $	��a14��5D      $
��Left=�6'   $��2��6B   $
��Wrap=�6O   $��	TextBlock��6c   $	��Top=�6t   $��67��6�   $��28��6�   $��5��6�   �� 5E      -   5        $	��a13��5E      $
��Left=�6'   $��2��6B   $
��Wrap=�6O   $��	TextBlock��6c   $	��Top=�6t   $��67��6�   $��28��6�   $��4��6�   �� 5F      -   5        $	��a33��5F      $
��Left=�6'   $��4��6B   $
��Wrap=�6O   $��	TextBlock��6c   $	��Top=�6t   $��71��6�   $��29��6�   $��4��6�   $��1,0,0,0q�6�   �� 5G      -   5        $	��a32��5G      $
��Left=�6'   $��4��6B   $
��Wrap=�6O   $��	TextBlock��6c   $	��Top=�6t   $��67��6�   $��28��6�   $��3��6�   �� 5H      -   5        $	��a31��5H      $
��Left=�6'   $��4��6B   $
��Wrap=�6O   $��	TextBlock��6c   $	��Top=�6t   $��67��6�   $��29��6�   $��2��6�   $��1,0,0,0q�6�   �� 5I      -   5        $	��a34��5I      $
��Left=�6'   $��4��6B   $
��Wrap=�6O   $��	TextBlock��6c   $	��Top=�6t   $��67��6�   $��29��6�   $��5��6�   $ 0.612,0.576&�6�   �� 5J      -   5        $	��a04��5J      $
��Left=�6'   $��1��6B   $
��Wrap=�6O   $��	TextBlock��6c   $	��Top=�6t   $��66��6�   $��28��6�   $��5��6�   �� 5K      -   5        $	��a10��5K      $
��Left=�6'   $��2��6B   $
��Wrap=�6O   $��	TextBlock��6c   $	��Top=�6t   $��67��6�   $��28��6�   $��1��6�   �� 5L      -   5        $	��a30��5L      $
��Left=�6'   $��4��6B   $
��Wrap=�6O   $��	TextBlock��6c   $	��Top=�6t   $��67��6�   $��29��6�   $��1��6�   $��2,0,0,0q�6�   $��2��6�   �� 5M      -   5        $	��a40��5M      $
��Left=�6'   $��5��6B   $
��Wrap=�6O   $��	TextBlock��6c   $	��Top=�6t   $��67��6�   $��28��6�   $��1��6�   $��1,0,0,0q�6�   �� 5N      -   5        $	��a41��5N      $
��Left=�6'   $��5��6B   $
��Wrap=�6O   $��	TextBlock��6c   $	��Top=�6t   $��67��6�   $��28��6�   $��2��6�   �� 5O      -   5        $	��a42��5O      $
��Left=�6'   $��5��6B   $
��Wrap=�6O   $��	TextBlock��6c   $	��Top=�6t   $��67��6�   $��28��6�   $��3��6�   $��1,0,0,0q�6�   �� 5P      -   5        $	��a43��5P      $
��Left=�6'   $��5��6B   $
��Wrap=�6O   $��	TextBlock��6c   $	��Top=�6t   $��67��6�   $��28��6�   $��4��6�   $��1,0,0,0q�6�   �� 5Q      -   5        $	��a44��5Q      $
��Left=�6'   $��5��6B   $
��Wrap=�6O   $��	TextBlock��6c   $	��Top=�6t   $��67��6�   $��28��6�   $��5��6�   $��1,0,0,0q�6�   �� 5R      -   5        $	��a12��5R      $
��Left=�6'   $��2��6B   $
��Wrap=�6O   $��	TextBlock��6c   $	��Top=�6t   $��67��6�   $��28��6�   $��3��6�   $��2��6�   $��2,0,0,0q�6�   �� 5S      -   5        $	��a03��5S      $
��Left=�6'   $��1��6B   $
��Wrap=�6O   $��	TextBlock��6c   $��67��6t   $��4��6   $ 0.493,-0.121&�6�   �� 5T      $
��9:00��6   $
��Left=�6'   $��1��6B   $��50��6O   �� 5U      $��11:00��6   $
��Left=�6(   $��3��6C   $	��Top=�6P   $��49��6h   $��28��6s   $��1,0,0,0q�6   �� 5V      $��10:00��6   $
��Left=�6(   $��2��6C   $	��Top=�6P   $��51��6h   $��28��6s   $��2��6   �� 5W      $��12:00��6   $
��Left=�6(   $��4��6C   $	��Top=�6P   $��48��6h   $��28��6s   $��2,0,0,0q�6   �� 5X      $��13:00��6   $
��Left=�6(   $��5��6C   $	��Top=�6P   $��51��6h   $��28��6s   $��2��6   �� 5Y      $��14:00��6   $
��Left=�6(   $��6��6C   $	��Top=�6P   $��51��6h   $��28��6s   $��0,1,0,0q�6   $��2��6�   �� 5Z      -   5        $	��a50��5Z      $
��Left=�6'   $��6��6B   $
��Wrap=�6O   $��	TextBlock��6c   $	��Top=�6t   $��67��6�   $��29��6�   $��1��6�   $��1,0,0,0q�6�   �� 5[      -    5        $	��a51��5[      $
��Left=�6'   $��6��6B   $
��Wrap=�6O   $��	TextBlock��6c   $	��Top=�6t   $��67��6�   $��29��6�   $��2��6�   �� 5\      -!   5        $	��a52��5\      $
��Left=�6'   $��6��6B   $
��Wrap=�6O   $��	TextBlock��6c   $	��Top=�6t   $��67��6�   $��29��6�   $��3��6�   $��1,0,0,0q�6�   �� 5]      -"   5        $	��a53��5]      $
��Left=�6'   $��6��6B   $
��Wrap=�6O   $��	TextBlock��6c   $	��Top=�6t   $��67��6�   $��29��6�   $��4��6�   $��1,0,0,0q�6�   �� 5^      -#   5        $	��a54��5^      $
��Left=�6'   $��6��6B   $
��Wrap=�6O   $��	TextBlock��6c   $	��Top=�6t   $��67��6�   $��29��6�   $��5��6�   $��1,0,0,0q�6�   �� 5_      $��Sunday��6   $��1��6+   $
��Left=�6;   $��1,0,0,0q�6V   $
��Wrap=�6g   $	��Top=�6{   $��72��6�   $��28��6�   $��2��6�   �� 5`      $��Monday��6   $��2��6+   $
��Left=�6;   $��1,0,0,0q�6V   $
��Wrap=�6g   $	��Top=�6{   $��72��6�   $��28��6�   $��2��6�   �� 5a      $��Tuesday��6   $��3��6,   $
��Left=�6<   $��1,0,0,0q�6W   $
��Wrap=�6h   $	��Top=�6|   $��72��6�   $��28��6�   $��2��6�   �� 5b      $��	Wednesday��6   $��4��6.   $
��Left=�6>   $
��Wrap=�6Y   $	��Top=�6m   $��70��6�   $��28��6�   �� 5c      $��Thursday��6   $��5��6-   $
��Left=�6=   $��1,0,-2,0q�6X   $
��Wrap=�6j   $	��Top=�6~   $��72��6�   $��28��6�   5e      5g      5h      5l      