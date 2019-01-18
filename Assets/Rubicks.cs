using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubicks : MonoBehaviour {

	public GameObject EdgeGY;
	public GameObject CornerOGY;
	public GameObject CornerRGY;
	public GameObject EdgeOY;
	public GameObject CornerOBY;
	public GameObject EdgeBY;
	public GameObject CornerRBY;
	public GameObject EdgeRY;
	public GameObject MiddleY;
	
	public GameObject CornerOBW;
	public GameObject EdgeBW;
	public GameObject CornerRBW;
	public GameObject EdgeRW;
	public GameObject CornerRGW;
	public GameObject EdgeGW;
	public GameObject CornerOGW;
	public GameObject EdgeOW;
	public GameObject MiddleW;
	
	public GameObject Middle;
	public GameObject MiddleO;
	public GameObject EdgeOB;
	public GameObject MiddleB;
	public GameObject EdgeRB;
	public GameObject MiddleR;
	public GameObject EdgeRG;
	public GameObject MiddleG;
	public GameObject EdgeOG;
																				
	private bool rotateY_CW  = false;
	private bool rotateY_CCW = false;
	private bool rotateG_CW  = false;
	private bool rotateG_CCW = false;
	private bool rotateB_CW  = false;
	private bool rotateB_CCW = false;
	private bool rotateR_CW  = false;
	private bool rotateR_CCW = false;
	private bool rotateO_CW  = false;
	private bool rotateO_CCW = false;
	private bool rotateW_CW  = false;
	private bool rotateW_CCW = false;
	
	
	public const int ROTATE_SPEED = 3; // for sure make this divisible by 90. Thx!
	private const int TOTAL_FRAMES = 90/ROTATE_SPEED;
	public int rotationCountDown = 0;
	
	public enum Face {
		BLUE, GREEN, ORANGE, RED, WHITE, YELLOW
	}
	
	public GameObject[] y = new GameObject[9]; 
	public GameObject[] b = new GameObject[9]; 
	public GameObject[] g = new GameObject[9]; 
	public GameObject[] w = new GameObject[9]; 
	public GameObject[] o = new GameObject[9]; 
	public GameObject[] r = new GameObject[9]; 

	
	// Use this for initialization
	void Start () {
		// triple checked - these are all assigning correctly.

		y[0] = CornerOBY;
		y[1] = EdgeOY;
		y[2] = CornerOGY;
		y[3] = EdgeBY;
		y[4] = MiddleY;
		y[5] = EdgeGY;
		y[6] = CornerRBY;
		y[7] = EdgeRY;
		y[8] = CornerRGY;
		
		b[0] = CornerOBY;
		b[1] = EdgeBY;
		b[2] = CornerRBY;
		b[3] = EdgeOB;
		b[4] = MiddleB;
		b[5] = EdgeRB;
		b[6] = CornerOBW;
		b[7] = EdgeBW;
		b[8] = CornerRBW;

		r[0] = CornerRBY;
		r[1] = EdgeRY;
		r[2] = CornerRGY;
		r[3] = EdgeRB;
		r[4] = MiddleR;
		r[5] = EdgeRG;
		r[6] = CornerRBW;
		r[7] = EdgeRW;
		r[8] = CornerRGW;

		g[0] = CornerRGY;
		g[1] = EdgeGY;
		g[2] = CornerOGY;
		g[3] = EdgeRG;
		g[4] = MiddleG;
		g[5] = EdgeOG;
		g[6] = CornerRGW;
		g[7] = EdgeGW;
		g[8] = CornerOGW;
		
		o[0] = CornerOGY;
		o[1] = EdgeOY;
		o[2] = CornerOBY;
		o[3] = EdgeOG;
		o[4] = MiddleO;
		o[5] = EdgeOB;
		o[6] = CornerOGW;
		o[7] = EdgeOW;
		o[8] = CornerOBW;

		w[0] = CornerRBW;
		w[1] = EdgeRW;
		w[2] = CornerRGW;
		w[3] = EdgeBW;
		w[4] = MiddleW;
		w[5] = EdgeGW;
		w[6] = CornerOBW;
		w[7] = EdgeOW;
		w[8] = CornerOGW;		
	}
	
	void completeRotateCCW ( GameObject[] target, 
							GameObject[] top, 
							GameObject[] right, 
							GameObject[] bottom, 
							GameObject[] left,
							int t1, int t2, int t3, int r1, int r2, int r3, 	
							int b1, int b2, int b3, int l1, int l2, int l3) {
		GameObject[] old = new GameObject[9];
		for (int i = 0; i < 9; i++) {
			old [i] = target[i];
		}
		
		target[6] = old[0];
		target[3] = old[1];
		target[0] = old[2];
		target[7] = old[3];
	  //target[4] = old[4];
		target[1] = old[5];
		target[8] = old[6];
		target[5] = old[7];
		target[2] = old[8];
		top    [t1] = target[0];
		top    [t2] = target[1];
		top    [t3] = target[2];
		right  [r1] = target[2];
		right  [r2] = target[5];
		right  [r3] = target[8];
		bottom [b1] = target[8];
		bottom [b2] = target[7];
		bottom [b3] = target[6];
		left   [l1] = target[6];
		left   [l2] = target[3];
		left   [l3] = target[0];	
				
	}
	void completeRotateCW ( GameObject[] target, 
							GameObject[] top, 
							GameObject[] right, 
							GameObject[] bottom, 
							GameObject[] left,
							int t1, int t2, int t3, int r1, int r2, int r3, 	
							int b1, int b2, int b3, int l1, int l2, int l3) {
		GameObject[] old = new GameObject[9];
		for (int i = 0; i < 9; i++) {
			old [i] = target[i];
		}

		target[0] = old[6];
		target[1] = old[3];
		target[2] = old[0];
		target[3] = old[7];
	  //target[4] = old[4];
		target[5] = old[1];
		target[6] = old[8];
		target[7] = old[5];
		target[8] = old[2];
		top    [t1] = target[0];
		top    [t2] = target[1];
		top    [t3] = target[2];
		right  [r1] = target[2];
		right  [r2] = target[5];
		right  [r3] = target[8];
		bottom [b1] = target[8];
		bottom [b2] = target[7];
		bottom [b3] = target[6];
		left   [l1] = target[6];
		left   [l2] = target[3];
		left   [l3] = target[0];	
	}
	
	void rotateSide (GameObject[] side, Vector3 direction, bool CW){
		int dir = 1;
		if (!CW) {
			dir = -1;
		}
		for (int i = 0; i < 9; i++) {
			side[i].transform.RotateAround(Vector3.zero, direction, dir*ROTATE_SPEED);
		}
	}	
	
	// Update is called once per frame
	void Update () {
		if (rotationCountDown > 0) {
			if (rotateY_CW) {
				rotateSide (y, Vector3.up, true);
			} else if (rotateY_CCW) {
				rotateSide (y, Vector3.up, false);
			} else if (rotateG_CW) {
				rotateSide (g, Vector3.right, true);
			} else if (rotateG_CCW) {
				rotateSide (g, Vector3.right, false);
			} else if (rotateW_CW) {
				rotateSide (w, Vector3.down, true); 
			} else if (rotateW_CCW) {
				rotateSide (w, Vector3.down, false); 
			} else if (rotateR_CW) {
				rotateSide (r, Vector3.back, true); // "
			} else if (rotateR_CCW) {
				rotateSide (r, Vector3.back, false); // "
			} else if (rotateB_CW) {
				rotateSide (b, Vector3.left, true);
			} else if (rotateB_CCW) {
				rotateSide (b, Vector3.left, false);
			} else if (rotateO_CW) {
				rotateSide (o, Vector3.forward, true); //"
			} else if (rotateO_CCW) {
				rotateSide (o, Vector3.forward, false); //"
			}
			rotationCountDown --;
		}
		if (rotationCountDown == 0) {			
			if (rotateY_CW) {
				completeRotateCW  ( y, o, g, r, b, 2,1,0, 2,1,0, 2,1,0, 2,1,0 );
				rotateY_CW = false;
			} else if (rotateY_CCW) {
				completeRotateCCW ( y, o, g, r, b, 2,1,0, 2,1,0, 2,1,0, 2,1,0 ); // good
				rotateY_CCW = false;
			} else if (rotateB_CW){
				completeRotateCW  ( b, y, r, w, o, 0,3,6, 0,3,6, 0,3,6, 8,5,2 );
				rotateB_CW = false;
			} else if (rotateB_CCW){
				completeRotateCCW ( b, y, r, w, o, 0,3,6, 0,3,6, 0,3,6, 8,5,2 ); // fixed
				rotateB_CCW = false;
			} else if (rotateR_CW){
				completeRotateCW  ( r, y, g, w, b, 6,7,8, 0,3,6, 2,1,0, 8,5,2 );
				rotateR_CW = false;
			} else if (rotateR_CCW){
				completeRotateCCW ( r, y, g, w, b, 6,7,8, 0,3,6, 2,1,0, 8,5,2 ); // checked		
				rotateR_CCW = false;
			} else if (rotateG_CW){
				completeRotateCW  ( g, y, o, w, r, 8,5,2, 0,3,6, 8,5,2, 8,5,2 );
				rotateG_CW = false;
			} else if (rotateG_CCW){
				completeRotateCCW ( g, y, o, w, r, 8,5,2, 0,3,6, 8,5,2, 8,5,2 ); // checked
				rotateG_CCW = false;
			} else if (rotateO_CW){
				completeRotateCW  ( o, y, b, w, g, 2,1,0, 0,3,6, 6,7,8, 8,5,2 ); 
				rotateO_CW = false;
			} else if (rotateO_CCW){
				completeRotateCCW  ( o, y, b, w, g, 2,1,0, 0,3,6, 6,7,8, 8,5,2 ); // check
				rotateO_CCW = false;
			} else if (rotateW_CW){
				completeRotateCW  ( w, r, g, o, b, 6,7,8, 6,7,8, 6,7,8, 6,7,8 );
				rotateW_CW = false;
			} else if (rotateW_CCW){
				completeRotateCCW  ( w, r, g, o, b, 6,7,8, 6,7,8, 6,7,8, 6,7,8 ); // check
				rotateW_CCW = false;
			}
		}
	}
	
	public void rotate (Face face, bool turnCW) {
		if (rotationCountDown == 0) {
			if (turnCW) {
				switch (face) {
					case Face.BLUE:
						rotateB_CW = true;
						break;
					case Face.GREEN:
						rotateG_CW = true;
						break;
					case Face.ORANGE:
						rotateO_CW = true;
						break;
					case Face.RED:
						rotateR_CW = true;
						break;
					case Face.WHITE:
						rotateW_CW = true;
						break;
					case Face.YELLOW:
						rotateY_CW = true;
						break;
				}
			} else {
				switch (face) {
					case Face.BLUE:
						rotateB_CCW = true;
						break;
					case Face.GREEN:
						rotateG_CCW = true;
						break;
					case Face.ORANGE:
						rotateO_CCW = true;
						break;
					case Face.RED:
						rotateR_CCW = true;
						break;
					case Face.WHITE:
						rotateW_CCW = true;
						break;
					case Face.YELLOW:
						rotateY_CCW = true;
						break;
				}				
			}
			rotationCountDown = TOTAL_FRAMES;			
		}
	}
	
	public void rotateYCW()	{
		rotate(Face.YELLOW, true);
	}
	public void rotateYCCW()	{
		rotate(Face.YELLOW, false);
	}
	public void rotateRCW()	{
		rotate(Face.RED, true);
	}
	public void rotateRCCW()	{
		rotate(Face.RED, false);
	}
	public void rotateGCW()	{
		rotate(Face.GREEN, true);
	}
	public void rotateGCCW()	{
		rotate(Face.GREEN, false);
	}
	public void rotateBCW()	{
		rotate(Face.BLUE, true);
	}
	public void rotateBCCW()	{
		rotate(Face.BLUE, false);
	}
	public void rotateOCW()	{
		rotate(Face.ORANGE, true);
	}
	public void rotateOCCW()	{
		rotate(Face.ORANGE, false);
	}
	public void rotateWCW()	{
		rotate(Face.WHITE, true);
	}
	public void rotateWCCW()	{
		rotate(Face.WHITE, false);
	}
	
}
