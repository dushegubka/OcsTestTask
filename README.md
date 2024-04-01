## Системные требования
Docker | Docker-Compose

## Инструкция по запуску

1. Клонируете репозиторий
```
git clone https://github.com/dushegubka/OcsTestTask
```
2. Переходите в папку с проектом

```
cd OcsTestTask
```
3. Запускаете docker compose
```
docker-compose -f docker-compose.yml up
```


### Для начала работы с заявками вам нужно будет создать хотя бы одного пользователя
Эндпоинт
```
[post]
/users
```


## OpenApi Схема

<!-- Generator: Widdershins v4.0.1 -->

<h1 id="ocs-api">Ocs.Api v1.0</h1>

> Scroll down for example requests and responses.

<h1 id="ocs-api-activities">Activities</h1>

## get__Activities



`GET /Activities`

> Example responses

> 200 Response

```
[{"activity":"Report","description":"string"}]
```

```json
[
  {
    "activity": "Report",
    "description": "string"
  }
]
```

<h3 id="get__activities-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|Inline|

<h3 id="get__activities-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[ActivityView](#schemaactivityview)]|false|none|none|
|» activity|[ActivityType](#schemaactivitytype)|false|none|none|
|» description|string¦null|false|none|none|

#### Enumerated Values

|Property|Value|
|---|---|
|activity|Report|
|activity|Masterclass|
|activity|Discussion|

<aside class="success">
This operation does not require authentication
</aside>

<h1 id="ocs-api-applications">Applications</h1>

## post__Applications



`POST /Applications`

> Body parameter

```json
{
  "author": "32ad2cdb-22a2-48aa-a42c-1c53a9afc4bd",
  "activity": "Report",
  "name": "string",
  "description": "string",
  "outline": "string"
}
```

<h3 id="post__applications-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[ApplicationCreateView](#schemaapplicationcreateview)|false|none|

> Example responses

> 200 Response

```
{"id":"497f6eca-6276-4993-bfeb-53cbbbba6f08","author":"32ad2cdb-22a2-48aa-a42c-1c53a9afc4bd","activity":"Report","name":"string","description":"string","outline":"string"}
```

```json
{
  "id": "497f6eca-6276-4993-bfeb-53cbbbba6f08",
  "author": "32ad2cdb-22a2-48aa-a42c-1c53a9afc4bd",
  "activity": "Report",
  "name": "string",
  "description": "string",
  "outline": "string"
}
```

<h3 id="post__applications-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[ApplicationView](#schemaapplicationview)|

<aside class="success">
This operation does not require authentication
</aside>

## get__Applications



`GET /Applications`

<h3 id="get__applications-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|submittedAfter|query|string|false|none|

> Example responses

> 200 Response

```
[{"id":"497f6eca-6276-4993-bfeb-53cbbbba6f08","author":"32ad2cdb-22a2-48aa-a42c-1c53a9afc4bd","activity":"Report","name":"string","description":"string","outline":"string"}]
```

```json
[
  {
    "id": "497f6eca-6276-4993-bfeb-53cbbbba6f08",
    "author": "32ad2cdb-22a2-48aa-a42c-1c53a9afc4bd",
    "activity": "Report",
    "name": "string",
    "description": "string",
    "outline": "string"
  }
]
```

<h3 id="get__applications-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|Inline|

<h3 id="get__applications-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[ApplicationView](#schemaapplicationview)]|false|none|none|
|» id|string(uuid)|false|none|none|
|» author|string(uuid)|false|none|none|
|» activity|[ActivityType](#schemaactivitytype)|false|none|none|
|» name|string¦null|false|none|none|
|» description|string¦null|false|none|none|
|» outline|string¦null|false|none|none|

#### Enumerated Values

|Property|Value|
|---|---|
|activity|Report|
|activity|Masterclass|
|activity|Discussion|

<aside class="success">
This operation does not require authentication
</aside>

## post__Applications_{id}_submit



`POST /Applications/{id}/submit`

<h3 id="post__applications_{id}_submit-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|string(uuid)|true|none|

<h3 id="post__applications_{id}_submit-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|None|

<aside class="success">
This operation does not require authentication
</aside>

## put__Applications_{id}



`PUT /Applications/{id}`

> Body parameter

```json
{
  "activity": "Report",
  "name": "string",
  "description": "string",
  "outline": "string"
}
```

<h3 id="put__applications_{id}-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|string(uuid)|true|none|
|body|body|[ApplicationEditView](#schemaapplicationeditview)|false|none|

> Example responses

> 200 Response

```
{"id":"497f6eca-6276-4993-bfeb-53cbbbba6f08","author":"32ad2cdb-22a2-48aa-a42c-1c53a9afc4bd","activity":"Report","name":"string","description":"string","outline":"string"}
```

```json
{
  "id": "497f6eca-6276-4993-bfeb-53cbbbba6f08",
  "author": "32ad2cdb-22a2-48aa-a42c-1c53a9afc4bd",
  "activity": "Report",
  "name": "string",
  "description": "string",
  "outline": "string"
}
```

<h3 id="put__applications_{id}-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[ApplicationView](#schemaapplicationview)|

<aside class="success">
This operation does not require authentication
</aside>

## get__Applications_{id}



`GET /Applications/{id}`

<h3 id="get__applications_{id}-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|string(uuid)|true|none|

> Example responses

> 200 Response

```
{"id":"497f6eca-6276-4993-bfeb-53cbbbba6f08","author":"32ad2cdb-22a2-48aa-a42c-1c53a9afc4bd","activity":"Report","name":"string","description":"string","outline":"string"}
```

```json
{
  "id": "497f6eca-6276-4993-bfeb-53cbbbba6f08",
  "author": "32ad2cdb-22a2-48aa-a42c-1c53a9afc4bd",
  "activity": "Report",
  "name": "string",
  "description": "string",
  "outline": "string"
}
```

<h3 id="get__applications_{id}-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[ApplicationView](#schemaapplicationview)|

<aside class="success">
This operation does not require authentication
</aside>

## delete__Applications_{id}



`DELETE /Applications/{id}`

<h3 id="delete__applications_{id}-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|string(uuid)|true|none|

> Example responses

> 200 Response

```
true
```

```json
true
```

<h3 id="delete__applications_{id}-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|boolean|

<aside class="success">
This operation does not require authentication
</aside>

## get__Applications_{unsubmittedOlder}



`GET /Applications/{unsubmittedOlder}`

<h3 id="get__applications_{unsubmittedolder}-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|unsubmittedOlder|path|string|true|none|

> Example responses

> 200 Response

```
[{"id":"497f6eca-6276-4993-bfeb-53cbbbba6f08","author":"32ad2cdb-22a2-48aa-a42c-1c53a9afc4bd","activity":"Report","name":"string","description":"string","outline":"string"}]
```

```json
[
  {
    "id": "497f6eca-6276-4993-bfeb-53cbbbba6f08",
    "author": "32ad2cdb-22a2-48aa-a42c-1c53a9afc4bd",
    "activity": "Report",
    "name": "string",
    "description": "string",
    "outline": "string"
  }
]
```

<h3 id="get__applications_{unsubmittedolder}-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|Inline|

<h3 id="get__applications_{unsubmittedolder}-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[ApplicationView](#schemaapplicationview)]|false|none|none|
|» id|string(uuid)|false|none|none|
|» author|string(uuid)|false|none|none|
|» activity|[ActivityType](#schemaactivitytype)|false|none|none|
|» name|string¦null|false|none|none|
|» description|string¦null|false|none|none|
|» outline|string¦null|false|none|none|

#### Enumerated Values

|Property|Value|
|---|---|
|activity|Report|
|activity|Masterclass|
|activity|Discussion|

<aside class="success">
This operation does not require authentication
</aside>

<h1 id="ocs-api-users">Users</h1>

## get__Users_{userId}_currentapplication



`GET /Users/{userId}/currentapplication`

<h3 id="get__users_{userid}_currentapplication-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|userId|path|string(uuid)|true|none|

> Example responses

> 200 Response

```
{"id":"497f6eca-6276-4993-bfeb-53cbbbba6f08","author":"32ad2cdb-22a2-48aa-a42c-1c53a9afc4bd","activity":"Report","name":"string","description":"string","outline":"string"}
```

```json
{
  "id": "497f6eca-6276-4993-bfeb-53cbbbba6f08",
  "author": "32ad2cdb-22a2-48aa-a42c-1c53a9afc4bd",
  "activity": "Report",
  "name": "string",
  "description": "string",
  "outline": "string"
}
```

<h3 id="get__users_{userid}_currentapplication-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[ApplicationView](#schemaapplicationview)|

<aside class="success">
This operation does not require authentication
</aside>

## post__Users



`POST /Users`

> Body parameter

```json
{
  "name": "string"
}
```

<h3 id="post__users-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[UserCreateView](#schemausercreateview)|false|none|

> Example responses

> 200 Response

```
{"id":"497f6eca-6276-4993-bfeb-53cbbbba6f08","name":"string"}
```

```json
{
  "id": "497f6eca-6276-4993-bfeb-53cbbbba6f08",
  "name": "string"
}
```

<h3 id="post__users-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[UserView](#schemauserview)|

<aside class="success">
This operation does not require authentication
</aside>

# Schemas

<h2 id="tocS_ActivityType">ActivityType</h2>
<!-- backwards compatibility -->
<a id="schemaactivitytype"></a>
<a id="schema_ActivityType"></a>
<a id="tocSactivitytype"></a>
<a id="tocsactivitytype"></a>

```json
"Report"

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|string|false|none|none|

#### Enumerated Values

|Property|Value|
|---|---|
|*anonymous*|Report|
|*anonymous*|Masterclass|
|*anonymous*|Discussion|

<h2 id="tocS_ActivityView">ActivityView</h2>
<!-- backwards compatibility -->
<a id="schemaactivityview"></a>
<a id="schema_ActivityView"></a>
<a id="tocSactivityview"></a>
<a id="tocsactivityview"></a>

```json
{
  "activity": "Report",
  "description": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|activity|[ActivityType](#schemaactivitytype)|false|none|none|
|description|string¦null|false|none|none|

<h2 id="tocS_ApplicationCreateView">ApplicationCreateView</h2>
<!-- backwards compatibility -->
<a id="schemaapplicationcreateview"></a>
<a id="schema_ApplicationCreateView"></a>
<a id="tocSapplicationcreateview"></a>
<a id="tocsapplicationcreateview"></a>

```json
{
  "author": "32ad2cdb-22a2-48aa-a42c-1c53a9afc4bd",
  "activity": "Report",
  "name": "string",
  "description": "string",
  "outline": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|author|string(uuid)|false|none|none|
|activity|[ActivityType](#schemaactivitytype)|false|none|none|
|name|string¦null|false|none|none|
|description|string¦null|false|none|none|
|outline|string¦null|false|none|none|

<h2 id="tocS_ApplicationEditView">ApplicationEditView</h2>
<!-- backwards compatibility -->
<a id="schemaapplicationeditview"></a>
<a id="schema_ApplicationEditView"></a>
<a id="tocSapplicationeditview"></a>
<a id="tocsapplicationeditview"></a>

```json
{
  "activity": "Report",
  "name": "string",
  "description": "string",
  "outline": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|activity|[ActivityType](#schemaactivitytype)|false|none|none|
|name|string¦null|false|none|none|
|description|string¦null|false|none|none|
|outline|string¦null|false|none|none|

<h2 id="tocS_ApplicationView">ApplicationView</h2>
<!-- backwards compatibility -->
<a id="schemaapplicationview"></a>
<a id="schema_ApplicationView"></a>
<a id="tocSapplicationview"></a>
<a id="tocsapplicationview"></a>

```json
{
  "id": "497f6eca-6276-4993-bfeb-53cbbbba6f08",
  "author": "32ad2cdb-22a2-48aa-a42c-1c53a9afc4bd",
  "activity": "Report",
  "name": "string",
  "description": "string",
  "outline": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|id|string(uuid)|false|none|none|
|author|string(uuid)|false|none|none|
|activity|[ActivityType](#schemaactivitytype)|false|none|none|
|name|string¦null|false|none|none|
|description|string¦null|false|none|none|
|outline|string¦null|false|none|none|

<h2 id="tocS_UserCreateView">UserCreateView</h2>
<!-- backwards compatibility -->
<a id="schemausercreateview"></a>
<a id="schema_UserCreateView"></a>
<a id="tocSusercreateview"></a>
<a id="tocsusercreateview"></a>

```json
{
  "name": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|name|string¦null|false|none|none|

<h2 id="tocS_UserView">UserView</h2>
<!-- backwards compatibility -->
<a id="schemauserview"></a>
<a id="schema_UserView"></a>
<a id="tocSuserview"></a>
<a id="tocsuserview"></a>

```json
{
  "id": "497f6eca-6276-4993-bfeb-53cbbbba6f08",
  "name": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|id|string(uuid)|false|none|none|
|name|string¦null|false|none|none|


