package com.dadhichabhishek;

public class PointCoordinate {
    private int X;

    public final int getX() {
        return X;
    }

    public final void setX(int value) {
        X = value;
    }

    private int Y;

    public final int getY() {
        return Y;
    }

    public final void setY(int value) {
        Y = value;
    }

    public PointCoordinate(int x, int y) {
        setX(x);
        setY(y);
    }
}
