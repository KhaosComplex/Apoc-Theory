while True:
	try:
    		mode=float(raw_input('Enter your Y value:'))
	except ValueError:
    		print "Not a number"

	print -(mode-5)/10