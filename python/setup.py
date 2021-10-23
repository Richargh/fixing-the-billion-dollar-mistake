from setuptools import setup, find_packages


with open('README.md') as f:
    readme_text = f.read()

setup(
    name='example',
    version='0.0.1',
    description='Example code',
    long_description=readme_text,
    packages=find_packages(exclude=('tests',))
)