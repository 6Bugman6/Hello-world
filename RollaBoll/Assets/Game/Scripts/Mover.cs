using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float x_start, x_end, x_speed, y_start, y_end, y_speed, z_start, z_end, z_speed;
    private bool dir_x, dir_y,dir_z;

    private Vector3 start_pos, movment;
    private int mx, my, mz;

    void Start()
    {
        start_pos = transform.position;
        dir_x = x_end > x_start;
        dir_y = y_end > y_start;
        dir_z = z_end > z_start;
        mx = startChek(dir_x,x_start,x_end,x_speed, transform.position.x);
        my = startChek(dir_y, y_start, y_end, y_speed, transform.position.y);
        mz = startChek(dir_z, z_start, z_end, z_speed, transform.position.z);
        movment.x = mx * x_speed / 10;
        movment.y = my * y_speed / 10;
        movment.z = mz * z_speed / 10;
    }

    void Update ()
    {
        moving(dir_x, x_start, x_end, movment.x, out movment.x, transform.position.x);
        moving(dir_y, y_start, y_end, movment.y, out movment.y, transform.position.y);
        moving(dir_z, z_start, z_end, movment.z, out movment.z, transform.position.z);

        transform.position += movment;
	}
    int startChek(bool a,float x1, float x2, float vx, float x)
    {
        int m;
        if (a)
        {
            m = 1;
            if (x <= x1 && vx < 0 || x >= x2 && vx > 0) m = -1;
        }
        else
        {
            m = 1;
            if (x <= x2 && vx < 0 || x >= x1 && vx > 0) m = -1;
        }
        return m;
    }
    void moving(bool a, float x1, float x2,float movx1,out float movx2,float x)
    {
        movx2 = movx1;
        if (a)
        {
            if (x <= x1 && movx1 < 0) movx2 = -movx1;
            if (x >= x2 && movx1 > 0) movx2 = -movx1;
        }
        else
        {
            if (x >= x1 && movx1 > 0) movx2 = -movx1;
            if (x <= x2 && movx1 < 0) movx2 = -movx1;
        }
    }
   
}
