   M S B A M L   `   `   `  ����M  IFlightSimulatorWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:FlightSimulatorWpf.controlsFlightSimulatorWpf.controls  5      I)clr-namespace:FlightSimulatorWpf.controlsFlightSimulatorWpf.controls  5      ,    &FlightSimulatorWpf.controls.MyJoystick   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      9Joy)clr-namespace:FlightSimulatorWpf.controls     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:FlightSimulatorWpf.controls     5      .��5
      �   J� RenderTransformOrigin$  0.5,0.5&�6    � ColumnDefinitions 5   
   �� 5      $��80 �6   �� 5      $	��300 �6   �� 5      $��80 �6    � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $	��240 �6   �� 5      .+�5   
   �� -   5         ��Name$ ThrottleSlider��5      
�������$��0��6C   $��29,56,21.8,29q�6S    � Minimum$ 0Q�6k    � Maximum$ 1Q�6w    � Value$	 0.5Q�6�    �� TickPlacement$ BottomRight=�6�    �� TickFrequency$	 0.1Q�6�   	 �� Orientation$	 Vertical=�6�   $��2��6�   �� 5   
   $��0��6   $��1��6    $��Throttle��6-   $��16(�6@   $
��Bold"�6N   $
��Left=�6a   $��2��6�   $��10,205,290.6,29q�6�   $��2��6�   �� 5   
   $��1��6   $��0��6%   $��2��62   $��0.2,27,80.4,214q�6F   $��2��6_   .+�5      �� $��-30,0,-0.2,0q�6   $��Aileron��6+   $��16(�6=   $
��Bold"�6K   $��Center=�6^   $  0.484,0.419&�6�   �� 5      -   5        $ AileronSlider��5      
�������$��
5,0,45.8,0q�6=   $ -1Q�6R   $ 1Q�6_   $	 0.5Q�6k   $ BottomRight=�6w   $	 0.1Q�6�   $��30��6�   $	��250��6�   5      *   $FlightSimulatorWpf.controls.Joystick  5   
   -   5        
  Name$
 MyRudder��5      $  0.5,0.5&�6+   $	��Top=�6K   $��41,31,80.4,0q�6j   $��3��6�   $��2��6�   z�5      V� 5       .~�5!      ��  �� ScaleX$	 0.5Q�6%    �� ScaleY$	 0.5Q�62   �� 5"      �� 5#      T� 5$      5%      5'      �� 5)   
   $��1��6   $��36.2,185,71.6,24q�6   $��
--Rudder--��68   $��16(�6M   $
��Bold"�6[   $��Center=�6n   $��1��6�   �� 5*   
   $��1��6   $��1��6   $��176.2,81,3.6,120q�6-   $��--Elevator--��6H   $��16(�6_   $
��Bold"�6m   $��Center=�6�   $��Center=�6�   $  0.5,0.5&�6�   z�5+      V� 5,      .~�5-      �� $
 1.15Q�6%   �� 5.      �� 5/       �� Angle$ 90Q�6&   T� 50      51      53      55      59      