#region Import
	GetInput()
#endregion

#region Macros
	#macro HORIZONTAL_AXIS 0
	#macro VERTICAL_AXIS 1

	#macro GRAVITY 0.3

	#macro SAVEFILE "Save.sav"	
#endregion

#region Enums
	enum TRANSITION_MODE {
		OFF,
		NEXT,
		GOTO,
		RESTART,
		INTRO,
	};
#endregion