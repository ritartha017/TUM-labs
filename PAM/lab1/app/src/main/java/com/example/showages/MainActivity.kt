package com.example.showages

import android.app.DatePickerDialog
import android.os.Bundle
import android.widget.Button
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import java.util.*

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        val btnPickDate = findViewById<Button>(R.id.btn_pick_date)
        btnPickDate.setOnClickListener {
            val datePicker = initDatePicker()
            datePicker.show()
        }
    }

    private fun initDatePicker(): DatePickerDialog {
        val getDate: Calendar = Calendar.getInstance()
        val datePicker = DatePickerDialog(
            this,
            android.R.style.Theme_Holo_Light_Dialog_MinWidth,
            { _, i, i2, i3 ->
                val selectDate : Calendar = Calendar.getInstance()
                selectDate.set(Calendar.YEAR, i)
                selectDate.set(Calendar.MONTH, i2)
                selectDate.set(Calendar.DAY_OF_MONTH, i3)
                val age = getAge(
                    selectDate[Calendar.YEAR], selectDate[Calendar.MONTH], selectDate[Calendar.DAY_OF_MONTH])
                Toast.makeText(this, "Your age : $age", Toast.LENGTH_SHORT).show()
            },
            getDate.get(Calendar.YEAR), getDate.get(Calendar.MONTH), getDate.get(Calendar.DAY_OF_MONTH)
        )
        return datePicker
    }

    private fun getAge(year: Int, month: Int, day: Int): String {
        val dob = Calendar.getInstance()
        val today = Calendar.getInstance()
        dob[year, month] = day
        var age = today[Calendar.YEAR] - dob[Calendar.YEAR]
        if (today[Calendar.DAY_OF_YEAR] < dob[Calendar.DAY_OF_YEAR])
            age--
        val ageInt = age
        return ageInt.toString()
    }
}