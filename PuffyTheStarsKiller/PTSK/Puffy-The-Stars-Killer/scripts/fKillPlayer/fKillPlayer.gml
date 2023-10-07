function fKillPlayer() {
	
	with (oGun)
		instance_destroy();

	instance_change(oPDead, true);

	direction = point_direction(other.x, other.y, x, y)

	Speed[H] = lengthdir_x(6, direction)
	Speed[V] = lengthdir_y(4, direction) - 6

	if (sign(Speed[H]) != 0)
		image_xscale = sign(Speed[H]);

	life = 0;
}