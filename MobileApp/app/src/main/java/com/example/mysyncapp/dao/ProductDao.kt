// MobileApp/app/src/main/java/com/example/mysyncapp/dao/ProductDao.kt
@Dao
interface ProductDao {
    @Insert(onConflict = OnConflictStrategy.REPLACE)
    suspend fun insert(product: Product)

    @Query("SELECT * FROM products WHERE last_modified > :lastSync")
    suspend fun getChanges(lastSync: Long): List<Product>
}
