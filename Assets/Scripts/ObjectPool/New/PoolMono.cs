using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class PoolMono<T> where T : MonoBehaviour
    {
        public T prefab { get; } //ссылка на префаб из которого создаются объекты
        //public T prefabMassiv[] { get; }
        public bool autoExpand { get; set; } //флаг авторасширяемость пула
        public Transform container { get; } //трансформ в который будут складываться все объекты
        
        private List<T> pool; //лист где будут хранится ссылки на созданные объекты

        public PoolMono(T prefab, int count) //конструктор пула
        {
            this.prefab = prefab;
            this.container = null;//создание на сцене, без контейнера.
            this.CreatePool(count);
        }
        public PoolMono(T prefab, int count, Transform container) //конструктор пула
        {
            this.prefab = prefab;
            this.container = container;
            this.CreatePool(count);
        }
        //public PoolMono(prefab[], int count, Transform container) //задумка конструктора пула с Массивом объектов, разобраться как
        //{
        //    this.prefab[] = prefab[];
        //    this.container = container;

        //    this.CreatePool(count);
        //}
        private void CreatePool(int count) //метод создания пула с переданной ёмкостью
        {
            this.pool = new List<T>(); //определяем пул

            for (int i = 0; i < count; i++)
            {
                this.CreateObject(); //создаем объекты в пуле
            }
        }

        private T CreateObject(bool isActiveByDefault = false) //метод создания объекта
        {
            var createdObject = UnityEngine.Object.Instantiate(this.prefab, this.container); //создаем переменную
            createdObject.gameObject.SetActive(isActiveByDefault); //вкл либо отключаем
            this.pool.Add(createdObject); //добавляем в пул
            return createdObject; //возвращаем
        }
       
        public bool HasFreeElement(out T element) //обязательный метод(запрос на свободный элемент в пуле)
        {
            foreach(var mono in pool)
            {
                if(!mono.gameObject.activeInHierarchy) //если объект отключен то его можно возвращать
                {
                    element = mono;
                    mono.gameObject.SetActive(true);
                    return true;
                }
            }
            element = null;
            return false;
        }
        public T GetFreeElement()
        {
            if (this.HasFreeElement(out var element))
                return element;

            if (this.autoExpand)
                return this.CreateObject(true);

            throw Nothing();
            //throw new Exception($"Нет свободных элементов в пуле типа {typeof(T)}");
            //throw Debug.Log("need time");????????????
        }

        private Exception Nothing()
        {
            Debug.Log("Оружие перезаряжается, подождите");
            return null;

            //throw new NotImplementedException("Оружие заряжается!"); //Обдумать как доделать перезарядку, добавить UI или звук.
        }
    }
} 