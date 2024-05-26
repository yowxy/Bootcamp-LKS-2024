package com.example.esemkapetitionv2

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Toast
import com.example.esemkapetitionv2.databinding.ActivityRegisterBinding
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.GlobalScope
import kotlinx.coroutines.launch
import org.json.JSONObject
import java.net.HttpURLConnection
import java.net.URL

class Register : AppCompatActivity() {
    lateinit var binding: ActivityRegisterBinding
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        binding = ActivityRegisterBinding.inflate(layoutInflater)
        setContentView(binding.root)

        binding.SingnIN.setOnClickListener {
            startActivity(Intent(this@Register,MainActivity::class.java))
        }

        binding.singnUP.setOnClickListener {

            GlobalScope.launch(Dispatchers.IO){
                val conn = URL("http://10.0.2.2:5000/sign-up").openConnection() as HttpURLConnection
                conn.requestMethod="POST"
                conn.setRequestProperty("Content-Type","application/json")

                val jsons = JSONObject().apply {
                    put("firstname",binding.firstname.text)
                    put("lastname",binding.Lastname.text)
                    put("email",binding.Email.text)
                    put("password",binding.password.text)
                }

                conn.outputStream.write(jsons.toString().toByteArray())


                if(conn.responseCode in 200..299) {
                    runOnUiThread {
                        startActivity(Intent(this@Register, Mainscreen::class.java))
                        finish()
                    }

                }
                else{

                    val error = conn.errorStream.bufferedReader().readText()
                    runOnUiThread {
                        try {
                            Toast.makeText(this@Register, "${JSONObject(error).getString("message")}", Toast.LENGTH_SHORT).show()
                        }
                        catch (e : Exception) {
                            Toast.makeText(this@Register, "Pastikan Semua Data Terisi!$error", Toast.LENGTH_SHORT).show()
                        }
                    }
                }
            }
        }
    }
}