# ProgaWeb3TP
 
# Entornos

Para poder manejar distintos entornos y que cada persona tenga su propia base de datos se debe hacer lo siguiente:

* Crear una variable de entorno llamada **ENTORNO_TP** con valor igual al nombre del desarrollador/ra Ej: maca
* Crear un archivo de configuracion en el proyecto llamado: **nombre**.appsettings.json Ej: maca.appsettings.json
* En este archivo agregar la config que se desea sobrescribir del archivo appsettings.json original.

```json
{
  "ConnectionStrings": {
    "_20211CTPContext": "Server=<server-local>;Database=2021-1C-TP;Trusted_Connection=True;"
  }
}
```

Modificar <server-local> en el connection string con la dirección de la base de datos local.