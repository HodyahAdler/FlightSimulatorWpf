   M S B A M L   `   `   `  ����M  IFlightSimulatorWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:FlightSimulatorWpf.controlsFlightSimulatorWpf.controls  5      ,    &FlightSimulatorWpf.controls.TunedBoard   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:FlightSimulatorWpf.controls     5      
�������$	��320��5   5   .��5	      � .+�5
   
   �� $��8��6   .+�5      �� 
����� �.+�5      �� $��20(�6   $��
UltraBlack"�6+     �� Padding$  1q�5      $��Tuned Board��6$   $��Center=�67   5      �� 5      $��heading deg��6   $��
UltraBlack"�6+   $  1q�6C   $��Center=�6O   $��15(�6l   � 5      -   5        $��
headingDeg��5      $
��Left=�5       � Maximum$	 400Q�65   $��6q�6C   $	��400��6O   $��10��5      $��5,2,5,0q�6&   
��� ��� � Value 5   ,   �� *VM_HeadingDeg+ �� Mode$ OneWay=�5   7   �� 5      $��
ExtraBlack"�6L   $��Center=�5      $��Center=�65   $��	0,-14,0,0q�6P   ��5      ��  �� ElementName$ 
headingDeg�� �� Path$ Value�5   P   �� 5      $��vertical speed��6   $��
UltraBlack"�6.   $  1q�6G   $��Center=�6S   $��15(�6p   � 5      -   5         �Name$ verticalSpeed��5      $
��Left=�5      $	 400Q�65   $	��400��6C   $��6q�6O   $��10��5      $��5,2,5,0q�6&   
����+�� 5   1   �� *VM_VerticalSpeed+$ OneWay=�5   7   �� 5      $��
ExtraBlack"�6O   $��Center=�5      $��Center=�65   $��	0,-14,0,0q�6P   ��5      �� $ verticalSpeed��$ Value�5   P   �� 5      $��ground speed��6   $��
UltraBlack"�6,   $  1q�6D   $��Center=�6P   $��15(�6m   � 5      -   5        $ groundSpeed��5      $
��Left=�5      $	 400Q�65   $	��400��6C   $��6q�6O   $��10��5      $��5,2,5,0q�6&   
���� K� 5   /   �� *VM_GroundSpeed+$ OneWay=�5   7   �� 5      $��
ExtraBlack"�6M   $��Center=�5       $��Center=�65   $��	0,-14,0,0q�6P   ��5      �� $ groundSpeed��$ Value�5    P   �� 5!      $��indicator indicated speed��6   $��
UltraBlack"�69   $  1q�6Q   $��Center=�6]   $��15(�6z   � 5"      -   5        $ indicatedSpeed��5"      $
��Left=�5#      $	 400Q�65   $	��400��6C   $��6q�6O   $��10��5$      $��5,2,5,0q�6&   
���i�� 5"   2   �� *VM_IndicatedSpeed+$ OneWay=�5$   7   �� 5%      $��
ExtraBlack"�6P   $��Center=�5&      $��Center=�65   $��	0,-14,0,0q�6P   ��5%      �� $ indicatedSpeed��$ Value�5&   P   �� 5'      $��gps indicated altitude��6   $��
UltraBlack"�66   $  1q�6N   $��Center=�6Z   $��15(�6w   � 5(      -   5        $ gpsAltitude��5(      $
��Left=�5)      $	 400Q�65   $	��400��6C   $��6q�6O   $��10��5*      $��5,2,5,0q�6&   
����·� 5(   /   �� *VM_GpsAltitude+$ OneWay=�5*   7   �� 5+      $��
ExtraBlack"�6M   $��Center=�5,      $��Center=�65   $��	0,-14,0,0q�6P   ��5+      �� $ gpsAltitude��$ Value�5,   P   �� 5-      $��indicator internal roll��6   $��
UltraBlack"�67   $  1q�6O   $��Center=�6[   $��15(�6x   � 5.      -   5        $ internalRoll��5.      $
��Left=�5/      $	 400Q�65   $	��400��6C   $��6q�6O   $��10��50      $��5,2,5,0q�6&   
����� � 5.   0   �� *VM_InternalRoll+$ OneWay=�50   7   �� 51      $��
ExtraBlack"�6N   $��Center=�52      $��Center=�65   $��	0,-14,0,0q�6P   ��51      �� $ internalRoll��$ Value�52   P   �� 53      $��indicator internal pitch��6   $��
UltraBlack"�68   $  1q�6P   $��Center=�6\   $��15(�6y   � 54      -   5        $ internalPitch��54      $
��Left=�55      $	 400Q�65   $	��400��6C   $��6q�6O   $��10��56      $��5,2,5,0q�6&   
����  � 54   1   �� *VM_InternalPitch+$ OneWay=�56   7   �� 57      $��
ExtraBlack"�6P   $��Center=�58      $��Center=�65   $��	0,-14,0,0q�6P   ��57      �� $ internalPitch��$ Value�58   P   �� 59      $"��altimeter indicated altitude��6   $��
UltraBlack"�6<   $  1q�6T   $��Center=�6`   $��15(�6}   � 5:      -   5        $ altimeterAltitude��5:      $
��Left=�5;      $	 400Q�65   $	��400��6C   $��6q�6O   $��10��5<      $��5,2,5,0q�6&   
���� �� 5:   5   �� *VM_AltimeterAltitude+$ OneWay=�5<   7   �� 5=      $��
ExtraBlack"�6S   $��Center=�5>      $��Center=�65   $��	0,-14,0,0q�6P   ��5=      �� $ altimeterAltitude��$ Value�5>   P   5?      5@      5A      