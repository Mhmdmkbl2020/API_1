// MobileApp/app/src/main/java/com/example/mysyncapp/api/ApiService.kt
interface ApiService {
    @GET("sync/pull")
    suspend fun pullChanges(@Query("lastSync") lastSync: Long): List<Product>

    @POST("sync/push")
    suspend fun pushChanges(@Body changes: List<Product>)
}

object RetrofitClient {
    private const val BASE_URL = "https://your-api-domain.com/"

    val instance: ApiService by lazy {
        Retrofit.Builder()
            .baseUrl(BASE_URL)
            .addConverterFactory(GsonConverterFactory.create())
            .build()
            .create(ApiService::class.java)
    }
}
