   M S B A M L   `   `   `  ����   MultimediaPlayer    MediaPlayerWPF.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     �Name$  
RootWindow�� � Title$ 
MainWindow��$��509.008��$��1076.971�� � WindowStyle$
 None=� � Icon$ Resources/icono2.png��$��0q� � WindowStartupLocation$ CenterScreen=� � AllowsTransparency . 
������  � 
ResizeMode$ NoResize=�.��� -    �Name$ RootGrid������  �� ImageSource$, &Resources/abstract-colorful_651523.jpg��	 j� Stretch$	 UniformToFill=�.+��� -   
 ��Name$
 
bordelista�� �� CornerRadius$ 1��$	��486��$��
950,22,0,0q�$	��Top=����	#CC000000._��� -    ��Name$ lbLista��
������  J� 	AllowDrop . ���	#FF008BFF$��10(���Z� � -   $ 	gridmedia��$��
0,22,127,0q�.+�r� -    r�Name$ mediacontrol�� r� UnloadedBehavior$ Manual=� .  r� LoadedBehavior$ Manual=� r� Stretch$
 Fill=� r� Volume �� *Value+ �� ElementName$ 	slidervol���� -   $
 bordercontroles�����	#00000000$��0q�$��22��$	��Top=�
���   �._�� -   $ GridControls��$��0,0,321,-100q�.+��� -	    ��Name$ btcerrar��$��1057,2,-319,102q�$��0q�
������ $��18��$��18������ $ Resources/btn_close_p.png���� -
   $ 
btminimiza��$��Bottom=�$��1040,-1,-302,105q�$��0q�
������ $��18��$��18�� J� RenderTransformOrigin$ 	0.5,-1.37&����� $ Resources/btn_min_p.png��9� -    9�Name$ expandmedios��$��Medios��$
��Left=�$	��Top=� 9� 
IsExpanded .  ���	#FF00ADFD$	��117��$	��111��$��10(�   ExpanderStilo#���   .���� -   $
 bordermedios��$ 8��$
��Left=�$��97��$	��Top=�$	��109�����	#99000000._�o� -    o�Name$ 	menufiles��
������ 
�������$��10(���Z� .@�m� -    m�Name$ 
subarchivo��$��Abrir Archivos��m� -   $ subarchivos��$��Abrir Varios Archivos...��m� -   $ subsalir��$��Salir��9� -   $ 	expestado�� .  $��Reproducción��$
��Left=�$	��Top=����	#FF00ADFD$	��119��$��	114,0,0,0q�$	��109��$��10(�#���   .���� -   $
 borderestado��$��0,0,10,0q�$ 8��$
��Left=�$��95��$	��Top=�$��92�����	#99000000._�o� -   $ 
menuestado��
������ 
�������$��10(���Z� .@�m� -   $ subplay��$��
Reproducir��m� -   $ subpausa��$��Pausar��m� -   $ subanterior��$��Anterior��m� -   $ subsiguienter��$��	Siguiente��m� -   $ substop��$��Detener��9� -   $ expaudio�� .  $��Audio��$
��Left=�$	��Top=����	#FF00ADFD$	��119��$��	250,0,0,0q�$	��107��$��10(�#���   .���� -   $
 borderaudio��$��0,0,10,0q�$ 8��$
��Left=�$��95��$	��Top=�$��92�����	#99000000._�o� -   $ 	menuaudio��
������ 
�������$��10(���Z� .@�m� -   $ subabriraudio��$��Abrir Pista��m� -   $ subabriraudios��$��Abrir Pistas...��m� -   $ subsubirvol��$��	Volumen +��m� -   $ subbajarvol��$��	Volumen -��9� -    $ expvideo�� .  $��Video��$
��Left=�$	��Top=����	#FF00ADFD$	��119��$��	365,0,0,0q�$��99��$��10(�#���   .���� -!   $
 bordervideo��$ 8��$
��Left=�$��95��$	��Top=�$��94�����	#99000000._�o� -"   $ menuestado2��
������ 
�������$��10(���Z� .@�m� -#   $ subabrirvideo��$��Abrir Videos��m� -$   $ subfullscreen��$��Pantalla Completa���� -%    ��Name$ lbAbout��$��	YOUPLAYER��$
��Left=�$	��Top=�$��
520,-4,0,0q�
���   �$��Arial Rounded MT Bold)�$	��103��$��26�����	#FF008BFF$��15(�$
��Bold"� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ 	#FFFBFBFB��   Opacity$	 0.8Q��� -&   $ lbAbou2��$��The Perfect Design��$
��Left=�$	��Top=�$��	620,3,0,0q�
���   �$��
Levenim MT)�$��86��$��21��
�������$��8(�$��Italic$�$ 0.5,0.5&�z�V� .~��� ��  �� AngleY$ 0.187Q��� T�  T� Y$ 0.247Q��� -'     ��Name$  
tnFacebook��$
��Wrap=�$��960,4,-288,106q����	#FF003370$ 5.417,0.656&�$��8(����� $ Resources/facebook.png��$	 Uniform=��� -(   $$��https://facebook.com/edwinupds?�.�
facebook�� -)   $
 BorderMediaControls��$��0,444,127,5q����	#00000000._�� -*   $ GridControl��.+��� -+   ! ��Name$! 	slidervol��$
��Left=�$	��Top=�$��57��$��831,33,0,-3q�$��30��" � Maximum$" 1Q�# �� TickFrequency$	# 0.1Q�$ � Value$	$ 0.5Q�% �� IsMoveToPointEnabled% .  
 Estilo#���  �� -,   $ lbrepeat��$��Repetir��$
��Left=�$��
376,18,0,0q�$	��Top=�
�������$��8(����� & �� 
TargetType"& ��.��� ' �� Property' � y�( �� Value$( 	Collapsed=�) �� Triggers) �� * �� Binding* �� *IsMouseOver+$ btRepeat��+ �� Value+ True.a��� ' � y�$( Visible=��� --   $ lbstop��$��Detener��$
��Left=�$��
414,17,0,0q�$	��Top=�
�������$��8(����� "& ��.��� ' � y�$( 	Collapsed=�) �� * �� *IsMouseOver+$ btStop��+ True.a��� ' � y�$( Visible=��� -.   $ lbback��$��Anterior��$
��Left=�$��
449,17,0,0q�$	��Top=�
�������$��8(����� "& ��.��� ' � y�$( 	Collapsed=�) �� * �� *IsMouseOver+$ btBack��+ True.a��� ' � y�$( Visible=��� -/   $ lbPausa��$��Pausa��$
��Left=�$��
474,17,0,0q�$	��Top=�
�������$��8(����� "& ��.��� ' � y�$( 	Collapsed=�) �� * �� *IsMouseOver+$ btPausa��+ True.a��� ' � y�$( Visible=��� -0   $ lbPlay��$��
Reproducir��$
��Left=�$��
467,17,0,0q�$	��Top=�
�������$��8(����� "& ��.��� ' � y�$( 	Collapsed=�) �� * �� *IsMouseOver+$ btPlay��+ True.a��� ' � y�$( Visible=��� -1   $ lbNext��$��	Siguiente��$
��Left=�$��
499,17,0,0q�$	��Top=�
�������$��8(����� "& ��.��� ' � y�$( 	Collapsed=�) �� * �� *IsMouseOver+$ btNext��+ True.a��� ' � y�$( Visible=��� -2   $ lbVol��$��	Silenciar��$
��Left=�$��
801,23,0,0q�$	��Top=�
�������$��8(����� "& ��.��� ' � y�$( 	Collapsed=�) �� * �� *IsMouseOver+$ btVol��+ True.a��� ' � y�$( Visible=��� -3   $ 
lbdesacrep��$��
No Repetir��$
��Left=�$��
376,18,0,0q�$	��Top=�
�������$��8(����� "& ��.��� ' � y�$( 	Collapsed=�) �� * �� *IsMouseOver+$ btRepeatActivo��+ True.a��� ' � y�$( Visible=��� -4   $ lbSCreen��$��
FullScreen��$
��Left=�$��
898,24,0,0q�$	��Top=�
�������$��8(�$��52������ "& ��.��� ' � y�$( 	Collapsed=�) �� * �� *IsMouseOver+$ btScreen��+ True.a��� ' � y�$( Visible=��� -5   , ��Name$, btRepeat��$
��Left=�$��20��$��
379,36,0,0q�$	��Top=�$��20��$��UniformToFill=�$ ��Resources/btn_Repeat_p.png��$ 0.667,0.167&��� -6   $, btStop��$
��Left=�$��20��$��
417,36,0,0q�$	��Top=�$��20��$��UniformToFill=�$��Resources/btn_stop_P.png���� -7   $, btBack��$
��Left=�$��20��$��
454,36,0,0q�$	��Top=�$��20��$��UniformToFill=�$"��Resources/btn_previous_P.png���� -8   $, btPausa��$
��Left=�$��20��$��
479,36,0,0q�$	��Top=�$��20��$��Resources/btn_pause_P.png��- �� StretchDirection$- DownOnly=��� -9   $, btPlay��$
��Left=�$��20��$��
479,36,0,0q�$	��Top=�$��20��$��Resources/btn_play_P.png��$- DownOnly=��� -:   $, btNext��$
��Left=�$��20��$��
504,36,0,0q�$	��Top=�$��20��$��UniformToFill=�$��Resources/btn_next_P.png���� -;   $, btVol��$
��Left=�$��20��$��
808,35,0,0q�$	��Top=�$��20��$��UniformToFill=�$ ��Resources/btn_volume_P.png���� -<   $, btRepeatActivo��$y�	Collapsed=�$
��Left=�$��20��$��
379,36,0,0q�$	��Top=�$��20��$��UniformToFill=�$!��Resources/Btn_RepeatC_p.png��$ 0.667,0.167&��� -=   $, btScreen��$
��Left=�$��13��$��
917,43,0,0q�$	��Top=�$��17��$!��Resources/dimensions(2).png���� ->   $! slideravance��$
��Left=�$��	47,10,0,0q�$	��Top=�$	��841��#���  % . �� -?   $ lbtime��$��893,8,24,31q�
�������$��10(��� $
��Left=�$��940,-25,0,0q�$
��Wrap=�$��	TextBlock��$	��Top=�