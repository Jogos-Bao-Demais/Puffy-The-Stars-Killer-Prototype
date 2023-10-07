function fReturnToNormalSpeed() {

	game_set_speed(60, gamespeed_fps)

}

/// @description SlideTransition (mode, targetroom)
/// @arg Mode Sets Transition Mode Between 'next, restart and goto'
/// @arg Target Sets Target Room when Using the 'goto' mode
function fSlide_Transition(Mode, Target) {
	
	//set Primitive\\
	with (oTransition) {
		
		mode = Mode
		
		if (argument_count > 1) {
			
			target = Target
			
		}
		
	}
	
	if (oTransition.percent <= 0.1) {
		 
		fReturnToNormalSpeed();
	
	}
	
}
