   M S B A M L   `   `   `  ����M  IFlightSimulatorWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:FlightSimulatorWpf.controlsFlightSimulatorWpf.controls  5      )    #FlightSimulatorWpf.controls.Message   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:FlightSimulatorWpf.controls     5      
�������$��50��5      $
��1100��6     � 	Resources  5
       �� 
TargetType �� Property �� Value �� Triggers �� Binding �� Value �� 
TargetType��%�  '��       '�� �    �� 5   
   " ��6   .�5      ��  � |� .  6*    5      �� 5       6   ��  The server is offline5      .a�5      ��  � �� �	#FFF911115      5      �� 5       6   ��  Unexpected Error5      .a�5      ��  � �� �	#FF0096FF5      5      �� 5       6   ��  The server is very Slow5      .a�5      ��  � �� �	#FFFFDC005      5      �� 5       6   �� 0 ,The Airplane is out of Boundaries - latitude5       .a�5!      ��  � �� �	#FF40C01F5"      5#      �� 5$       6   �� 1 -The Airplane is out of Boundaries - longitude5%      .a�5&      ��  � �� �	#FF40C01F5'      5(      5*      �� 5+   
   " ��6   .�5,      ��  � ��
 ���� 6+   �� 5-       � �� 5.      �� 5/      " ��6&   .R�50      �� $
��Left=�6+   $��2,3,2,3q�6F   51      53      54      55      .��57      ]� .+�58   
   �� -   5        $
��Left=�58      $	��120��6'   $��80 0 0 0q�63   $
��Bold"�6E   $��18(�6W   .��6�   
Disconnect6�   �� 59   
   -   5        $��General_Errors��59      $��60 0 0 0q�6-   $	��600��6?   $
��auto=�5:      $��50��6>   $
��auto=�5;      ��. .��5>      �� -   5        $��general_errors_list��5>      
�������$��-4q�5?      $��Center=�6    $��11(�6D   $
��Bold"�6R   ��5>   2   �� *VM_GeneralErrList+5@      5A      �� 5B   
   -   5        $��Right=�5B      $	��120��6(   $
��Bold"�64   $��18(�6F   .��6s   	Reconnect6~   5D      5G      