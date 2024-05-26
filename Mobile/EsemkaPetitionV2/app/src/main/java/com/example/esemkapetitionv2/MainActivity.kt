package com.example.esemkapetitionv2

import android.content.Context
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Toast
import com.example.esemkapetitionv2.databinding.ActivityMainBinding
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.GlobalScope
import kotlinx.coroutines.launch
import org.json.JSONObject
import java.io.DataOutputStream
import java.net.HttpURLConnection
import java.net.URL

class MainActivity : AppCompatActivity() {
    lateinit var  binding: ActivityMainBinding
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityMainBinding.inflate(layoutInflater)
        setContentView(binding.root)

        binding.Email.setText("Alexander@gmail.com")
        binding.password.setText("54321")

        binding.btnSingnup.setOnClickListener {
            startActivity(Intent(this@MainActivity,Register::class.java))
            Toast.makeText(this, "anda masuk ke menu register", Toast.LENGTH_SHORT).show()
        }


        binding.btnSingn.setOnClickListener{
            GlobalScope.launch(Dispatchers.IO){

                val conn = URL("http://10.0.2.2:5000/sign-in").openConnection() as HttpURLConnection
                conn.requestMethod="POST"
                conn.setRequestProperty("Content-Type","application/json")

                val jsons =  JSONObject().apply {
                    put("email", binding.Email.text)
                    put("password", binding.password.text)
                }


                conn.outputStream.write(jsons.toString().toByteArray())


                val code = conn.responseCode
                runOnUiThread {
                    if(code in 200..299){
                        getSharedPreferences("Coffee", Context.MODE_PRIVATE).edit().putString("token", conn.inputStream.bufferedReader().readText()).apply()
                        startActivity(Intent(this@MainActivity, Mainscreen::class.java))
                    }else{
                        val error = conn.errorStream.bufferedReader().readText()
                        Toast.makeText(this@MainActivity, "${error}", Toast.LENGTH_LONG).show()
                    }
                }

            }
        }



    }
}


