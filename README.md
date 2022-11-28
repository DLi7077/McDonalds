# McDonalds API

## Server info:

Server starts by clearing all tables and seeding it with meals and foods. For this reason, any posted data will be lost when the server is restarted. If this is undesired, remove the seeding function calls in lines 27-37 in `Program.cs`

The seeding file only contains a sample of McDonald's foods, because I can't bother myself with grabbing all the data.
Also I didn't add drinks because there's way too many of them.

## Routes

## Retrieve a list of foods

`GET: https://localhost:7091/api/food?sortBy={field}&sortDir={direction}`

returns an array of all food objects satisfying the optional query params.

`sortBy` : name, price, calories, protein, carbs, sodium, sugar, fat
<br/>
`sortDir` : asc, desc

<details>
<summary>Example Output with <code>https://localhost:7091/api/food?sortBy=protein&sortDir=desc</code></summary>

```json
{
  "status_code": 200,
  "description": "ok",
  "result": [
    {
      "id": 7,
      "name": "Double Quarter Pounder with Cheese",
      "price": 6.99,
      "calories": 740,
      "protein": 48,
      "carbs": 43,
      "sodium": 1360,
      "sugar": 10,
      "fat": 42
    },
    {
      "id": 18,
      "name": "20pc McNuggets",
      "price": 8.19,
      "calories": 830,
      "protein": 46,
      "carbs": 51,
      "sodium": 1670,
      "sugar": 0,
      "fat": 49
    },
    {
      "id": 4,
      "name": "Triple Cheeseburger",
      "price": 3.59,
      "calories": 540,
      "protein": 32,
      "carbs": 34,
      "sodium": 1280,
      "sugar": 7,
      "fat": 35
    },
    {
      "id": 6,
      "name": "Quarter Pounder with Cheese",
      "price": 5.79,
      "calories": 520,
      "protein": 30,
      "carbs": 42,
      "sodium": 1140,
      "sugar": 10,
      "fat": 26
    },
    {
      "id": 11,
      "name": "Deluxe Crispy Chicken Sandwich",
      "price": 5.59,
      "calories": 530,
      "protein": 27,
      "carbs": 48,
      "sodium": 1050,
      "sugar": 10,
      "fat": 26
    },
    {
      "id": 10,
      "name": "Crispy Chicken Sandwich",
      "price": 4.89,
      "calories": 470,
      "protein": 26,
      "carbs": 46,
      "sodium": 1140,
      "sugar": 9,
      "fat": 20
    },
    {
      "id": 3,
      "name": "Double Cheeseburger",
      "price": 2.89,
      "calories": 450,
      "protein": 25,
      "carbs": 34,
      "sodium": 1120,
      "sugar": 7,
      "fat": 24
    },
    {
      "id": 5,
      "name": "Big Mac",
      "price": 5.59,
      "calories": 550,
      "protein": 25,
      "carbs": 45,
      "sodium": 1010,
      "sugar": 9,
      "fat": 30
    },
    {
      "id": 17,
      "name": "10pc McNuggets",
      "price": 4.79,
      "calories": 420,
      "protein": 23,
      "carbs": 25,
      "sodium": 840,
      "sugar": 0,
      "fat": 25
    },
    {
      "id": 9,
      "name": "Filet-O-Fish",
      "price": 4.99,
      "calories": 390,
      "protein": 19,
      "carbs": 39,
      "sodium": 580,
      "sugar": 5,
      "fat": 19
    },
    {
      "id": 2,
      "name": "Cheeseburger",
      "price": 2.29,
      "calories": 300,
      "protein": 15,
      "carbs": 32,
      "sodium": 720,
      "sugar": 7,
      "fat": 13
    },
    {
      "id": 8,
      "name": "McChicken",
      "price": 4.2,
      "calories": 400,
      "protein": 14,
      "carbs": 39,
      "sodium": 560,
      "sugar": 5,
      "fat": 21
    },
    {
      "id": 16,
      "name": "6pc McNuggets",
      "price": 2.89,
      "calories": 250,
      "protein": 14,
      "carbs": 15,
      "sodium": 500,
      "sugar": 0,
      "fat": 15
    },
    {
      "id": 1,
      "name": "Hamburger",
      "price": 1.79,
      "calories": 250,
      "protein": 12,
      "carbs": 31,
      "sodium": 510,
      "sugar": 6,
      "fat": 9
    },
    {
      "id": 15,
      "name": "4pc McNuggets",
      "price": 1.99,
      "calories": 170,
      "protein": 9,
      "carbs": 10,
      "sodium": 330,
      "sugar": 0,
      "fat": 10
    },
    {
      "id": 14,
      "name": "Large Fries",
      "price": 4.99,
      "calories": 480,
      "protein": 7,
      "carbs": 65,
      "sodium": 400,
      "sugar": 0,
      "fat": 23
    },
    {
      "id": 13,
      "name": "Medium Fries",
      "price": 3.99,
      "calories": 320,
      "protein": 5,
      "carbs": 43,
      "sodium": 260,
      "sugar": 0,
      "fat": 15
    },
    {
      "id": 12,
      "name": "Small Fries",
      "price": 2.39,
      "calories": 230,
      "protein": 3,
      "carbs": 31,
      "sodium": 190,
      "sugar": 0,
      "fat": 11
    }
  ]
}
```

</details>
<br/>

## Add a single food

`POST: https://localhost:7091/api/food`
<br/>
Request Body - takes a single food object

```json
{
  "name": "Hamburger",
  "price": 1.79,
  "calories": 250,
  "protein": 12,
  "carbs": 31,
  "sodium": 510,
  "sugar": 6,
  "fat": 9
},
```

Response Body - an array of all food objects

```js
// Updated food list in database, same format as retrieving list of foods.
```

## Retrieve all combos

<details>
<summary>
Example Output with <code>https://localhost:7091/api/combo</code></summary>

```json
{
  "status_code": 200,
  "description": "success",
  "result": [
    {
      "combo": {
        "id": 3,
        "name": "Big Mac Meal",
        "price": 10.29
      },
      "foods": [
        {
          "id": 86,
          "name": "Big Mac",
          "price": 5.59,
          "calories": 550,
          "protein": 25,
          "carbs": 45,
          "sodium": 1010,
          "sugar": 9,
          "fat": 30
        },
        {
          "id": 94,
          "name": "Medium Fries",
          "price": 3.99,
          "calories": 320,
          "protein": 5,
          "carbs": 43,
          "sodium": 260,
          "sugar": 0,
          "fat": 15
        }
      ]
    },
    {
      "combo": {
        "id": 4,
        "name": "Quarter Pounder with Cheese Meal",
        "price": 9.59
      },
      "foods": [
        {
          "id": 87,
          "name": "Quarter Pounder with Cheese",
          "price": 5.79,
          "calories": 520,
          "protein": 30,
          "carbs": 42,
          "sodium": 1140,
          "sugar": 10,
          "fat": 26
        },
        {
          "id": 94,
          "name": "Medium Fries",
          "price": 3.99,
          "calories": 320,
          "protein": 5,
          "carbs": 43,
          "sodium": 260,
          "sugar": 0,
          "fat": 15
        }
      ]
    },
    {
      "combo": {
        "id": 5,
        "name": "Double Quarter Pounder with Cheese Meal",
        "price": 11.99
      },
      "foods": [
        {
          "id": 88,
          "name": "Double Quarter Pounder with Cheese",
          "price": 6.99,
          "calories": 740,
          "protein": 48,
          "carbs": 43,
          "sodium": 1360,
          "sugar": 10,
          "fat": 42
        },
        {
          "id": 94,
          "name": "Medium Fries",
          "price": 3.99,
          "calories": 320,
          "protein": 5,
          "carbs": 43,
          "sodium": 260,
          "sugar": 0,
          "fat": 15
        }
      ]
    },
    {
      "combo": {
        "id": 6,
        "name": "2 Filet O Fish",
        "price": 7
      },
      "foods": [
        {
          "id": 90,
          "name": "Filet-O-Fish",
          "price": 4.99,
          "calories": 390,
          "protein": 19,
          "carbs": 39,
          "sodium": 580,
          "sugar": 5,
          "fat": 19
        },
        {
          "id": 90,
          "name": "Filet-O-Fish",
          "price": 4.99,
          "calories": 390,
          "protein": 19,
          "carbs": 39,
          "sodium": 580,
          "sugar": 5,
          "fat": 19
        }
      ]
    },
    {
      "combo": {
        "id": 7,
        "name": "Crispy Chicken Sandwich Meal",
        "price": 9.39
      },
      "foods": [
        {
          "id": 91,
          "name": "Crispy Chicken Sandwich",
          "price": 4.89,
          "calories": 470,
          "protein": 26,
          "carbs": 46,
          "sodium": 1140,
          "sugar": 9,
          "fat": 20
        },
        {
          "id": 94,
          "name": "Medium Fries",
          "price": 3.99,
          "calories": 320,
          "protein": 5,
          "carbs": 43,
          "sodium": 260,
          "sugar": 0,
          "fat": 15
        }
      ]
    },
    {
      "combo": {
        "id": 8,
        "name": "Deluxe Crispy Chicken Sandwich Meal",
        "price": 9.99
      },
      "foods": [
        {
          "id": 92,
          "name": "Deluxe Crispy Chicken Sandwich",
          "price": 5.59,
          "calories": 530,
          "protein": 27,
          "carbs": 48,
          "sodium": 1050,
          "sugar": 10,
          "fat": 26
        },
        {
          "id": 94,
          "name": "Medium Fries",
          "price": 3.99,
          "calories": 320,
          "protein": 5,
          "carbs": 43,
          "sodium": 260,
          "sugar": 0,
          "fat": 15
        }
      ]
    }
  ]
}
```

</details>

## Add a bunch of food

`POST: https://localhost:7091/api/foods` <- `foods` is plural here (used for bulk insertion)
<br/>
Request Body - takes an array of food objects

```json
[
  "status_code": 200,
  "description": "ok",
  "result": [
    {
    "name": "Hamburger",
    "price": 1.79,
    "calories": 250,
    "protein": 12,
    "carbs": 31,
    "sodium": 510,
    "sugar": 6,
    "fat": 9
    },
    ...
  ]
]
```

Response Body - an array of all food objects

```js
// Updated food list in database, same format as retrieving list of foods.
```

## Add a combo

`POST: https://localhost:7091/api/combo`
<br/>
Request Body - a combo object

```json
{
  "name": "Big Mac Meal",
  "price": 9.2,
  "foods": ["Big Mac", "Medium Fries"]
}
```

Response Body - the created document with the name and price and all foods in it

```json
{
  "status_code": 200,
  "description": "ok",
  "result": {
    "name": "Big Mac Meal",
    "price": 9.2,
    "foods": [
      {
        "id": 5,
        "name": "Big Mac",
        "price": 5.59,
        "calories": 550,
        "protein": 25,
        "carbs": 45,
        "sodium": 1010,
        "sugar": 9,
        "fat": 30
      },
      {
        "id": 13,
        "name": "Medium Fries",
        "price": 3.99,
        "calories": 320,
        "protein": 5,
        "carbs": 43,
        "sodium": 260,
        "sugar": 0,
        "fat": 15
      }
    ]
  }
}
```
