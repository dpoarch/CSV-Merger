   M S B A M L   `   `   `  ����  CSV_Mergerv3    CSV_Mergerv3.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  CSV Merge Tool��5   	   $	��351��6    $	��524��6-   $	��350��69    � Icon$ images/icon.ico��6I   $	��525��6`   $	��525��6o   $	��350��6~   $
��Bold"�6�   .��5      � ���	#FFF5FCFE$��0,0,2,0q�6"   $	��330��63   $	��515��6C   $	��515��6R   $	��330��6a   .+�5   
   �� -   5         ��Name$ txtInputDir��5      $
��Left=�6'   $��25��6B   $��	10,67,0,0q�6N    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $	��485��6�    �� 
IsReadOnly .  �� SelectionBrush �	#FF00AEEF���	#FF00AEEF$��Center=�6�   $��Normal"�6   $��Arial Rounded MT Bold)�6  �� 5   
   -   5        $ txtOutputDir��5      $
��Left=�6(   $��25��6C   $��
10,145,0,0q�6O   $
 Wrap=�6c   $	��Top=�6w   $	��485��6�    . ���	#FF00AEEF$��Center=�6�   $��Normal"�6�   $��Arial Rounded MT Bold)�6�   �� 5   
   $9��3Directory which contains CSV files to join together��6   $
��Left=�6N   $��6,41,0,0q�6i   $	��Top=�6{   ���	#FFFD8C00$
��Bold"�6�   $��Arial Rounded MT Bold)�6�   $��14(�6�   �� 5	   
   $$��Directory to save joined files��6   $
��Left=�69   $��	6,119,0,0q�6T   $	��Top=�6g   ���	#FFFD8C00$
��Bold"�6�   $��Arial Rounded MT Bold)�6�   $��14(�6�   �� 5
   
   -   5         ��Name$ btnMerge��5
      $	��Run��6#   $��Right=�61   $��0,210,188,0q�6M   $	��Top=�6b   $	��152��6z   $��41��6�   ���	#FF01AFF0 J� RenderTransformOrigin$ 0.5,0.5&�6�   ���	#FFFDFDFD���	#FF01AFF0$��Arial Rounded MT Bold)�6�   $��14(�6  $
��Bold"�6)  $��0q�6;  6O  �� 5   
   -   5        $ btnBrowseInput��5      $
��Left=�6)   $��
467,67,0,0q�6D   $	��Top=�6X   $��28��6p   $��25��6{   ���	#FF00AFF0���	#FF0095CC.��5      �� .+�5      �� $��images/folder.png��6   $��16��63   5      5      �� 5   
   -   5        $ btnBrowseOutput��5      $
��Left=�6*   $��467,145,0,0q�6E   $	��Top=�6Z   $��28��6r   $ 0.669,2.618&�6}   $��25��6�   ���	#FF00AFF0���	#FF0095CC.��5      �� .+�5      �� $��images/folder.png��6   $��16��63   5      5      �� 5   
   -   5         ��Name$ statBar��5      $
��Left=�6%   $��25��6@   $��-2,285,-10,0q�6L   $	��Top=�6b   $	��527��6z   ���	#FFC7EDFC$��Bottom=�6�   .@�5      �� .��5      �� -   5        $��	lblStatus��5      $	��373��6-   $��7,0,0,0q�69   5      �� 5      $��Right=�6   $��0,0,25,0q�68   .��5      � -   5        	 �Name$	 progBar��5      
 � Minimum$
 1Q�60    � Maximum$	 100Q�6<   $	��102��6J   $��16��6V    J� IsManipulationEnabled . $��5,0,0,0q�6   $
��Left=�6�   5      5      �� 5   
   -	   5         ��Name$ 
lblPercent��5      $
��Left=�6(   $��400,289,0,0q�6C   $
��Wrap=�6X   $��0%��6l   $	��Top=�6v   $��Normal"�6�   $��95��6�    K� ZIndex$ 99��6�    �� TextAlignment$ Center=�6�   o� 5   
   $
��Left=�6   $��20��6*   $	��Top=�66   $	��515��6N   ���	#FFF5FCFE.@�5      m� $
��Help��6   $	��5,1q�6%   .@�5       m� -
   5        $��About��5       $��20��6*   $	��120��66   $��Arial Rounded MT Bold)�6B   6e   5!      5"      5#      5$      