package com.example.esemkapetitionv2

import android.app.Activity
import android.content.Context
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.widget.Toast
import com.example.esemkapetitionv2.databinding.ActivityCreateBinding
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.GlobalScope
import kotlinx.coroutines.launch
import org.json.JSONObject
import java.net.HttpURLConnection
import java.net.URL

class ActivityCreate : AppCompatActivity() {
    lateinit var  binding: ActivityCreateBinding
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_create)

        binding = ActivityCreateBinding.inflate(layoutInflater)
        setContentView(binding.root)

        binding.toolbar.setNavigationOnClickListener{
            setResult(Activity.RESULT_OK, Intent())
            finish()
        }



        var creatorid =this.getSharedPreferences("random", Context.MODE_PRIVATE).getString("user", "{}")
        var arrays =JSONObject(creatorid);

        binding.submit.setOnClickListener {
            GlobalScope.launch(Dispatchers.Main){
                val conn = URL("http://10.0.2.2:5000/petition").openConnection() as HttpURLConnection
                conn.requestMethod="POST"
                conn.setRequestProperty("Content-Type","application/json")

                val jsons = JSONObject().apply {
                    put("title",binding.createTitle.text)
                    put("description",binding.Description.text)
                    put("target",binding.Targettt.text)
                    put("creatorID", arrays.getString("userID"))
                }

                conn.outputStream.write(jsons.toString().toByteArray())
                    try{
                        if(conn.responseCode in 200..299){
                            setResult(Activity.RESULT_OK, Intent(this@ActivityCreate, Mainscreen::class.java))
                            finish()
                        }
                        else{
                            runOnUiThread{
                                Toast.makeText(this@ActivityCreate, "Error", Toast.LENGTH_SHORT).show()
                            }
                        }
                    }
                    catch (E:Exception){
                        Log.e("ActivityCreate", "Error: ", error(""))
                    }

            }
        }

    }
}