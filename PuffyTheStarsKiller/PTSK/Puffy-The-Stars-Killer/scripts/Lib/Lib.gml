#region Import
	
	GetInput()
	
#endregion

#region Macros

	#macro H 0
	#macro V 1

	#macro Horizontal key_right - key_left
	#macro Gravity 0.3

	#macro SAVEFILE "Save.sav"
	
#endregion

#region Enums

	enum TRANS_MODE {
	
		OFF,
		NEXT,
		GOTO,
		RESTART,
		INTRO,

	};
	
#endregion