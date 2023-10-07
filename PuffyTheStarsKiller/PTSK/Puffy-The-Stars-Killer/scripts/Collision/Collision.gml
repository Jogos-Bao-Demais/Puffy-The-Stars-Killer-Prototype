function Collision() {
	// Horizontal Collision
	if (place_meeting(x + Speed[H], y, oWall)) {	
		while (!place_meeting(x + sign(Speed[H]), y, oWall)) {		
			x += sign(Speed[H])			
		}		
		Speed[H] = 0		
	}	
	
	x += Speed[H]
	
	// Vertical
	if (place_meeting(x, y + Speed[V], oWall)) {		
		while (!place_meeting(x, y + sign(Speed[V]), oWall)) {		
			y += sign(speed[V])          
		}
		Speed[V] = 0  
	}
	
	y += Speed[V]  
}