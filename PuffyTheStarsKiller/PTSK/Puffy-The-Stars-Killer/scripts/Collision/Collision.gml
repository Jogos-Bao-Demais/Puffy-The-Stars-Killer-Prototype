function Collision() {
	// Horizontal Collision
	if (place_meeting(x + player_speed[HORIZONTAL_AXIS], y, pCollideable)) {	
		while (!place_meeting(x + sign(player_speed[HORIZONTAL_AXIS]), y, pCollideable)) {		
			x += sign(player_speed[HORIZONTAL_AXIS])			
		}		
		player_speed[HORIZONTAL_AXIS] = 0		
	}	
	
	x += player_speed[HORIZONTAL_AXIS]
	
	// Vertical
	if (place_meeting(x, y + player_speed[VERTICAL_AXIS], pCollideable)) {		
		while (!place_meeting(x, y + sign(player_speed[VERTICAL_AXIS]), pCollideable)) {		
			y += sign(speed[VERTICAL_AXIS])          
		}
		player_speed[VERTICAL_AXIS] = 0  
	}
	
	y += player_speed[VERTICAL_AXIS]  
}