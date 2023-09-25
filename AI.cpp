#include<stdio.h>
#include<math.h>
#include<winbgim.h>

void elip(int xc, int yc, int x,int y, int color){
	putpixel(xc+x, yc+y, color);
	putpixel(xc-x, yc+y, color);
	putpixel(xc+x, yc-y, color);
	putpixel(xc-x, yc-y, color);
}

// ve mien 1
void midpointelip(int xc, int yc, int rx, int ry){
	int x=0;
	int y=ry;
	// ve mien 1
	
	float p1= round(ry*ry - rx*rx*ry +rx*rx/4);
	int px=0;
	int py=2*rx*rx*y;
	while(px<py){
		elip(xc, yc, x, y, 4);
		px+= 2*ry*ry;
		x++;
		if(p1<0){
			p1=p1+ ry*ry+px;
		}
		else{
			y--;
			py  =py -2*rx*rx;
			p1  =p1 +ry*ry + px-py;
		}
	}
	// ve mien 2
	float p2=round(ry*ry*x*x + rx*rx*y*y - rx*rx*ry*ry);
	while(y>0){
		elip(xc, yc, x, y, 4);
		py =py -2*rx*rx;
		y--;
		if(p2>0){
			p2 =p2+rx*rx- py;	
		}
		else{
			x++;
			px  =px+ 2*ry*ry;
			p2  =p2+ rx*rx - py+px;
		}
	}	
}
//                  tron--------------------------------//
void circle(int xc, int yc, int x, int y, int color){
	putpixel(xc+x, yc+y, color);
    putpixel(xc-x, yc+y, color);
    putpixel(xc+x, yc-y, color);
    putpixel(xc-x, yc-y, color);
    putpixel(xc+y, yc+x, color);
    putpixel(xc-y, yc-x, color);
    putpixel(xc+y, yc-x, color);
    putpixel(xc-y, yc+x, color);
}

void midpoint( int xc, int yc, int r){
	int x=0;
	int y=r;
	circle(xc, yc, x, y, 4);
	int p=1-r;
	while(x<y){
		if(p<0){
			p=p+2*x+3;
		}
		else{
			p=p+2*(x-y)+5;
			y--;
		}
		x++;
		circle(xc,yc,x,y,4);
	}
}

int main(){
	initwindow(300,300);
	midpoint(200,100,50); /// x, y , ban kin
	midpointelip(200,200,100,50);// x, y, rong , cao
	midpoint(180,100,5); /// x, y , ban kinh
	midpoint(220,100,5); /// x, y , ban kinh
	getch();
}
