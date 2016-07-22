package com.algo.search;

import java.util.Arrays;

public class BinarySearch {
    public static void main(String[] args) {
        int[] arr = {6,3,2,1,8,9,4};
        Arrays.sort(arr);

        System.out.println("arr :" + Arrays.toString(arr));
        System.out.println("get index : " + search(arr, 7));
    }

    public static int search(int[] arr, int n) {
        return binarySearch(arr, 0, arr.length-1, n);
    }

    private static int binarySearch(int[] arr, int left, int right, int n) {
        if(left > right) return -1;

        int m = left + (right - left) / 2;
        if(n < arr[m]) return binarySearch(arr, left, m-1, n);
        else if(n > arr[m]) return binarySearch(arr, m+1, right, n);
        return m;

    }
}
