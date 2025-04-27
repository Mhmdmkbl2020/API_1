// MobileApp/app/src/main/java/com/example/mysyncapp/entities/Product.kt
@Entity(tableName = "products")
data class Product(
    @PrimaryKey(autoGenerate = true) val id: Int = 0,
    @ColumnInfo(name = "name") val name: String,
    @ColumnInfo(name = "last_modified") val lastModified: Long
)
