# \# 🍽️ RestoBar – Sistema de Gestión de Mesas y Pedidos

# 

# \## Integrantes

# 

# \- Marian Grisel Morales Bonadies - Legajo: 32687

# \- Aureliano Michilini - Legajo: 41043

# 

# \---

# 

# \# 📌 1. Introducción

# 

# \*\*RestoBar\*\* es una aplicación web diseñada para optimizar la administración operativa de un restaurante, permitiendo gestionar mesas, pedidos, insumos y personal de atención de manera centralizada.

# 

# El sistema busca facilitar el trabajo diario tanto de los meseros como de la gerencia, brindando herramientas para el control de pedidos, la asignación de mesas y la generación de reportes de gestión.

# 

# \---

# 

# \# 🎯 2. Objetivo

# 

# Desarrollar una solución web que permita administrar de forma eficiente la operación diaria de un restaurante, garantizando el seguimiento de los pedidos realizados, la correcta asignación de mesas y el control de los insumos disponibles.

# 

# \---

# 

# \# 🛠️ 3. Descripción General del Sistema

# 

# La aplicación permitirá gestionar la actividad diaria del restaurante mediante distintos módulos funcionales orientados a la administración y seguimiento de las operaciones.

# 

# El sistema contempla:

# 

# \- Gestión de usuarios.

# \- Administración de mesas.

# \- Asignación de mesas a meseros.

# \- Administración de insumos.

# \- Apertura y cierre de pedidos.

# \- Control de stock.

# \- Consultas y reportes operativos.

# 

# \---

# 

# \# 🗂️ 4. Entidades Principales

# 

# El sistema estará compuesto por las siguientes entidades principales:

# 

# \- Usuario

# \- Mesa

# \- Pedido

# \- DetallePedido

# \- Insumo

# \- AsignacionMesa

# 

# > Nota: Durante la etapa de diseño podrán surgir entidades complementarias necesarias para soportar la lógica de negocio.

# 

# \---

# 

# \# 👥 5. Roles del Sistema

# 

# \## 🔹 Gerente

# 

# Cuenta con acceso total a la aplicación.

# 

# Puede:

# 

# \- Administrar usuarios.

# \- Administrar meseros.

# \- Administrar mesas.

# \- Administrar insumos.

# \- Asignar y reasignar mesas.

# \- Consultar pedidos.

# \- Visualizar reportes.

# \- Supervisar la operación completa del restaurante.

# 

# \---

# 

# \## 🔹 Mesero

# 

# Cuenta con acceso restringido a las mesas que tenga asignadas.

# 

# Puede:

# 

# \- Consultar sus mesas asignadas.

# \- Abrir pedidos.

# \- Agregar productos a los pedidos.

# \- Modificar pedidos.

# \- Cerrar pedidos.

# \- Consultar la información relacionada con sus mesas.

# \- Confirmar solicitudes realizadas por los clientes.

# 

# \---

# 

# \# 📦 6. Módulos Funcionales

# 

# \## ✅ Gestión de Usuarios

# 

# Permite la autenticación y administración de usuarios del sistema.

# 

# Funciones principales:

# 

# \- Inicio de sesión.

# \- Gestión de perfiles.

# \- Administración de permisos.

# \- Control de acceso según rol.

# 

# \---

# 

# \## ✅ Gestión de Mesas

# 

# Permite administrar las mesas disponibles dentro del restaurante.

# 

# Funciones principales:

# 

# \- Alta de mesas.

# \- Modificación de información.

# \- Consulta de disponibilidad.

# \- Asignación de responsable.

# 

# \---

# 

# \## ✅ Gestión de Meseros

# 

# Permite administrar al personal encargado de la atención de las mesas.

# 

# Funciones principales:

# 

# \- Alta de meseros.

# \- Modificación de datos.

# \- Consulta de asignaciones.

# \- Seguimiento de actividad.

# 

# \---

# 

# \## ✅ Gestión de Insumos

# 

# Permite administrar los productos ofrecidos por el restaurante.

# 

# Incluye:

# 

# \- Platos.

# \- Bebidas.

# 

# Para cada insumo se registrará:

# 

# \- Nombre.

# \- Descripción.

# \- Precio.

# \- Stock disponible.

# \- Imagen asociada (\*\*A VALIDAR\*\*).

# 

# \---

# 

# \## ✅ Gestión de Pedidos

# 

# Permite registrar los consumos realizados por los clientes.

# 

# Funciones principales:

# 

# \- Apertura de pedidos.

# \- Incorporación de productos.

# \- Actualización de cantidades.

# \- Modificación de pedidos.

# \- Cierre de pedidos.

# \- Asociación automática con la mesa y el mesero responsable.

# 

# \### Regla de Negocio

# 

# Una misma mesa podrá registrar múltiples pedidos durante una misma jornada.

# 

# Cada pedido conservará su historial de forma independiente.

# 

# \---

# 

# \## ✅ Asignación de Mesas

# 

# Permite organizar la distribución de mesas entre los distintos meseros.

# 

# Funciones principales:

# 

# \- Asignación diaria.

# \- Reasignación de mesas.

# \- Consulta de mesas asignadas.

# 

# \---

# 

# \# 📋 7. Gestión Operativa

# 

# El flujo general de trabajo será:

# 

# 1\. El gerente asigna mesas a los meseros.

# 2\. El mesero visualiza las mesas bajo su responsabilidad.

# 3\. Se abre un pedido para una mesa.

# 4\. Se agregan insumos al pedido.

# 5\. Se actualiza el stock correspondiente.

# 6\. Se cierra el pedido una vez finalizada la atención.

# 7\. La información queda disponible para consultas y reportes.

# 

# \---

# 

# \# 📊 8. Reportes del Sistema

# 

# La aplicación permitirá consultar información operativa y de gestión mediante distintas vistas orientadas a la toma de decisiones.

# 

# Los reportes estarán basados en consultas sobre la información registrada durante la operación diaria del restaurante.

# 

# | Reporte | Descripción |

# |----------|-------------|

# | Pedidos abiertos | Visualización de todos los pedidos que se encuentran actualmente en curso |

# | Pedidos cerrados | Consulta de pedidos finalizados en una fecha determinada |

# | Historial de pedidos por mesa | Seguimiento de todos los pedidos realizados por una mesa |

# | Pedidos por mesero | Consulta de pedidos gestionados por un mesero específico |

# | Detalle de pedido | Visualización completa de los productos asociados a un pedido |

# | Consumo de insumos por fecha | Consulta de productos consumidos durante una jornada |

# | Stock actual de insumos | Estado actualizado del inventario disponible |

# | Insumos con stock crítico | Identificación de productos próximos a agotarse |

# | Mesas asignadas por mesero | Distribución actual de mesas entre los distintos meseros |

# | Mesas sin asignar | Identificación de mesas pendientes de asignación |

# | Mesas ocupadas y disponibles | Estado operativo de las mesas del restaurante |

# | Pedidos realizados entre fechas | Consulta histórica utilizando filtros de fecha |

# | Pedidos asociados a una mesa | Búsqueda de pedidos vinculados a una mesa específica |

# | Reasignaciones de mesas | Historial de cambios en la asignación de mesas a meseros |

# | Ventas por fecha | Consulta de importes generados durante una jornada determinada |

# 

# Estos reportes podrán ser utilizados por el perfil Gerente para supervisar la operación diaria del restaurante y realizar el seguimiento de la actividad comercial.

# 

# \---

# 

# \# 🔒 9. Seguridad

# 

# El acceso al sistema estará protegido mediante autenticación por usuario y contraseña.

# 

# Cada usuario accederá únicamente a las funcionalidades habilitadas para su perfil, garantizando la seguridad y confidencialidad de la información.

# 

# \---

# 

# \# 🧪 10. Funcionalidades a Validar

# 

# Las siguientes funcionalidades se encuentran sujetas a validación por parte de la cátedra y podrían incorporarse en futuras iteraciones del proyecto.

# 

# \---

# 

# \## 👤 Cliente Digital Asociado a una Mesa (A VALIDAR)

# 

# Se propone incorporar un tercer rol \*\*Cliente\*\*, asociado a cada mesa del restaurante.

# 

# El objetivo es permitir que los clientes puedan consultar el menú digital y generar solicitudes de productos desde la propia mesa.

# 

# \### Funcionalidades del Cliente

# 

# El cliente podrá:

# 

# \- Consultar el menú disponible.

# \- Visualizar nombre del producto.

# \- Visualizar descripción.

# \- Visualizar precio.

# \- Visualizar imagen ilustrativa.

# \- Agregar productos a una comanda pendiente.

# \- Enviar una comanda para su revisión.

# 

# El cliente NO podrá:

# 

# \- Confirmar comandas.

# \- Modificar comandas enviadas.

# \- Eliminar productos de comandas enviadas.

# \- Cancelar comandas enviadas.

# \- Cerrar pedidos.

# 

# \---

# 

# \### Flujo Propuesto

# 

# 1\. El mesero abre un pedido para una mesa.

# 2\. El cliente accede al menú digital asociado a dicha mesa.

# 3\. El cliente selecciona productos.

# 4\. El sistema consulta el stock disponible al agregar unidades.

# 5\. El cliente envía la comanda.

# 6\. La comanda queda pendiente de revisión.

# 7\. El mesero recibe la solicitud.

# 8\. El mesero valida la comanda.

# 9\. El sistema vuelve a verificar stock.

# 10\. Si existe disponibilidad, la comanda es confirmada.

# 11\. Los productos se incorporan al pedido.

# 12\. Se descuenta el stock correspondiente.

# 13\. El cliente puede generar nuevas comandas mientras el pedido permanezca abierto.

# 

# \---

# 

# \### Estados de una Comanda

# 

# Cada comanda atravesará distintos estados:

# 

# \- Pendiente.

\- Confirmada.
- Entregada.
===

# \- Rechazada.

# 

# Solamente las comandas confirmadas impactarán sobre el pedido y el stock.

# 

# \---

# 

# \### Relación entre Pedido y Comandas

# 

# Un pedido representa la cuenta completa asociada a una mesa.

# 

# Una comanda representa una solicitud puntual realizada por el cliente dentro de ese pedido.

# 

# Mientras el pedido permanezca abierto:

# 

# \- El cliente podrá generar múltiples comandas.

# \- Cada comanda será validada individualmente.

# \- Todas las comandas confirmadas se consolidarán dentro del mismo pedido.

# 

# Ejemplo:

# 

# Pedido Mesa 5

# 

# Comanda 1:

# 

# \- 1 Jugo de naranja

# 

# Comanda 2:

# 

# \- 1 Tostado

# 

# Resultado final del pedido:

# 

# \- 1 Jugo de naranja

# \- 1 Tostado

# 

# \---

# 

# \### Control Operativo del Mesero

# 

# El mesero será responsable de validar todas las comandas enviadas por los clientes.

# 

# Podrá:

# 

# \- Confirmar comandas.

# \- Rechazar comandas.

\- Eliminar productos sin stock.
- Confirmar la entrega de la comanda.
===

# \- Modificar productos antes de la confirmación.

# 

# Toda modificación posterior al envío deberá ser realizada por el mesero.

# 

# \---

# 

# \### Política de Actualización de Stock

# 

# El stock NO será descontado cuando el cliente agregue productos a una comanda.

# 

# El descuento se realizará únicamente cuando el mesero confirme la comanda.

# 

# Esta decisión permite evitar bloqueos innecesarios de stock y manejar correctamente solicitudes simultáneas.

# 

# \---

# 

# \### Manejo de Solicitudes Simultáneas

# 

# Puede ocurrir que distintos clientes soliciten simultáneamente un producto con stock limitado.

# 

# Ejemplo:

# 

# Stock disponible:

# 

# \- Jugo de naranja: 1 unidad.

# 

# Mesa 1:

# 

# \- Solicita 1 jugo de naranja.

# 

# Mesa 2:

# 

# \- Solicita 1 jugo de naranja.

# 

# Ambas comandas podrán generarse correctamente.

# 

# Si el mesero confirma primero la solicitud de la Mesa 1:

# 

# \- El stock pasa a ser 0.

# 

# Cuando el mesero intente confirmar la solicitud de la Mesa 2:

# 

# \- El sistema detectará la falta de stock.

# \- Se mostrará una notificación al mesero.

# \- El producto deberá ser removido de la comanda antes de continuar con la confirmación.

# 

# De esta forma se evita que el stock pueda quedar en valores negativos.

# 

# \---

# 

# \### Beneficios Esperados

# 

# \- Agilizar la toma de pedidos.

# \- Reducir tiempos de espera.

# \- Disminuir errores de carga.

# \- Permitir al cliente consultar el menú digital de forma autónoma.

# \- Mantener el control final del pedido bajo supervisión del mesero.

# \- Evitar inconsistencias de stock ante solicitudes simultáneas.

# 

# \---

# 

# \# 💻 11. Tecnologías Utilizadas

# 

# El proyecto será desarrollado utilizando las tecnologías y estructuras trabajadas durante la cursada:

# 

# \- ASP.NET WebForms

# \- C#

# \- SQL Server

# \- .NET Framework

# \- Arquitectura en capas:

# &#x20; - Dominio

# &#x20; - Negocio

# &#x20; - Web

# 

# \---

# 

