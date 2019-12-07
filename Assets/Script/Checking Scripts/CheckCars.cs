using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CheckCars : MonoBehaviour
{

    public moving_car [] cars_gold;
    public moving_car [] cars_ruby;

    /*
     * 0,0 -> -221.7f, 66.2f
     * 1,0 -> -175.2f, 66.2f
     * 2,0 -> -128.7f, 66.2f
     * 3,0 -> -80.5f, 66.2f
     * 4,0 -> -34, 66.2f
     * 
     * 1,3 -> -80.5f, -8.5f
     * 
     * 2,2 -> -128.7f, -78f
     * 3,2 -> -80.5f, -78f
     * 4,2 -> -34f, -78f
     * 5,2 -> 16f, -78f
     * 6,2 -> 63.1f, -78f
     */

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SolveEnigma()
    {
        cars_gold[0].gameObject.GetComponent<RectTransform>().localPosition = new Vector2(-80.5f, -78f);
        cars_gold[1].gameObject.GetComponent<RectTransform>().localPosition = new Vector2(-34f, -78f);
        cars_gold[2].gameObject.GetComponent<RectTransform>().localPosition = new Vector2(16f, -78f);
        cars_gold[3].gameObject.GetComponent<RectTransform>().localPosition = new Vector2(63.1f, -78f);

        cars_ruby[2].gameObject.GetComponent<RectTransform>().localPosition = new Vector2(-221.7f, 66.2f);
        cars_ruby[1].gameObject.GetComponent<RectTransform>().localPosition = new Vector2(-175.2f, 66.2f);
        cars_ruby[0].gameObject.GetComponent<RectTransform>().localPosition = new Vector2(-128.7f, 66.2f);

        cars_gold[0].pos.x = 3; cars_gold[0].pos.y = 2;
        cars_gold[1].pos.x = 4; cars_gold[1].pos.y = 2;
        cars_gold[2].pos.x = 5; cars_gold[2].pos.y = 2;
        cars_gold[3].pos.x = 6; cars_gold[3].pos.y = 2;

        cars_ruby[0].pos.x = 2; cars_ruby[0].pos.y = 0;
        cars_ruby[1].pos.x = 1; cars_ruby[1].pos.y = 0;
        cars_ruby[2].pos.x = 0; cars_ruby[2].pos.y = 0;

        ResetCars();
    }

    public void RefreshCarts()
    {
        for (int i = 0; i < cars_gold.Length; i++)
            cars_gold[i].ResetStart();
        for (int i = 0; i < cars_ruby.Length; i++)
            cars_ruby[i].ResetStart();
    }
    public void SolveHint2()
    {
        cars_ruby[2].gameObject.GetComponent<RectTransform>().localPosition = new Vector2(-221.7f, 66.2f);
        cars_ruby[2].pos.x = 0; cars_ruby[2].pos.y = 0;

        cars_ruby[1].gameObject.GetComponent<RectTransform>().localPosition = new Vector2(-175.2f, 66.2f);
        cars_ruby[1].pos.x = 1; cars_ruby[1].pos.y = 0;

        cars_ruby[0].gameObject.GetComponent<RectTransform>().localPosition = new Vector2(-128.7f, -78f);
        cars_ruby[0].pos.x = 2; cars_ruby[0].pos.x = 2;


        cars_gold[3].gameObject.GetComponent<RectTransform>().localPosition = new Vector2(63.1f, -78f);
        cars_gold[3].pos.x = 6; cars_gold[3].pos.y = 2;
        cars_gold[2].gameObject.GetComponent<RectTransform>().localPosition = new Vector2(16f, -78f);
        cars_gold[2].pos.x = 5; cars_gold[2].pos.y = 2;

        cars_gold[0].ResetStart();
        cars_gold[1].ResetStart();

        ResetCars();
    }

    public void SolveHint1()
    {
        cars_ruby[2].gameObject.GetComponent<RectTransform>().localPosition = new Vector2(-221.7f, 66.2f);
        cars_ruby[2].pos.x = 0; cars_ruby[2].pos.y = 0;

        cars_gold[3].gameObject.GetComponent<RectTransform>().localPosition = new Vector2(63.1f, -78f);
        cars_gold[3].pos.x = 6; cars_gold[3].pos.y = 2;

        cars_ruby[0].gameObject.GetComponent<RectTransform>().localPosition = new Vector2(-128.7f, -78f);
        cars_ruby[0].pos.x = 2; cars_ruby[0].pos.x = 2;

        cars_gold[0].ResetStart();
        cars_gold[1].ResetStart();
        cars_gold[2].ResetStart();

        cars_ruby[1].ResetStart();

        ResetCars();
    }

    public void ResetCars()
    {
        foreach(moving_car car in cars_gold)
        {
            car.ResetCar();
        }
        foreach (moving_car car in cars_ruby)
        {
            car.ResetCar();
        }
    }

    public void CheckSolution()
    {
        
        if (
            cars_gold[0].pos.x == 3 && cars_gold[0].pos.y == 2 &&
            cars_gold[1].pos.x == 4 && cars_gold[1].pos.y == 2 &&
            cars_gold[2].pos.x == 5 && cars_gold[2].pos.y == 2 &&
            cars_gold[3].pos.x == 6 && cars_gold[3].pos.y == 2 &&

            cars_ruby[0].pos.x == 2 && cars_ruby[0].pos.y == 0 &&
            cars_ruby[1].pos.x == 1 && cars_ruby[1].pos.y == 0 &&
            cars_ruby[2].pos.x == 0 && cars_ruby[2].pos.y == 0
        ){
            GameManager.instance.LoadSceneByIndex(GameManager.instance.indexRight);
        }
        else{
            GameManager.instance.LoadSceneByIndex(GameManager.instance.indexWrong);
        }


    }
}
